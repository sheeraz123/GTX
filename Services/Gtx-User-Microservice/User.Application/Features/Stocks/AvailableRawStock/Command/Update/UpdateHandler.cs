using AutoMapper;
using Common.Miscellaneous;
using Common.Miscellaneous.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using System.Data.Common;
using System.Transactions;
using User.Application.Contracts.Persistence;
using User.Application.Features.Stocks.StockMasters.Query.GetData;
using User.Domain.Entities;

namespace User.Application.Features.Stocks.AvailableRawStock.Command.Update
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, UpdateVm>
    {
        private readonly IAvailableRawStockRepository _repository;
        private readonly IRawStockInvoiceRepository rawStockInvoiceRepository;
        private readonly IStockMasterRepository stockMasterRepository;
        private readonly IRawStockTransactionRepository rawStockTransactionRepository;

        private readonly IBillingRawMaterialRepository billingRawMaterialRepository;
        private readonly IMapper _mapper;
        private readonly ImageServer _imageServer;

        public UpdateHandler(IAvailableRawStockRepository repository, IMapper mapper, IOptions<ImageServer> imageServer, IRawStockTransactionRepository rawStockTransactionRepository, IRawStockInvoiceRepository rawStockInvoiceRepository, IStockMasterRepository stockMasterRepository, IBillingRawMaterialRepository billingRawMaterialRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _imageServer = imageServer.Value;
            this.rawStockTransactionRepository = rawStockTransactionRepository;
            this.rawStockInvoiceRepository = rawStockInvoiceRepository;
            this.stockMasterRepository = stockMasterRepository;
            this.billingRawMaterialRepository = billingRawMaterialRepository;
        }


        public async Task<UpdateVm> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var entity = _mapper.Map<BillingRawMaterial>(request);
                var isExits = await billingRawMaterialRepository.GetAsync(s => s.ReverseBillingId == entity.Id);

                if (isExits != null && isExits.Count > 0)
                {
                    return new UpdateVm()
                    {
                        ResponseCode = "-1",
                        ResponseMessage = "Record Already exists"
                    };
                }
                //Reverse Operation
                var reveseBilling = await ReverseBilling(request);
                var reverseEntities = await ReverseInvoice(request, reveseBilling);

                foreach (var res in reverseEntities)
                {
                    var (transactionEntities, insertStock, UpdateStock) = await ReverseAailableEntities(request, res);
                    if (transactionEntities.Any())
                        await rawStockTransactionRepository.AddRangeAsync(transactionEntities);
                    if (UpdateStock is not null && UpdateStock.Count() > 0)
                        await _repository.UpdateRangeAsync(UpdateStock);
                }

                var billingEntity = await CreateBilling(request);
                var entities = await CreateInvoice(request, billingEntity);
                foreach (var res in entities)
                {
                    var (transactionEntities, insertStock, UpdateStock) = await CreateAailableEntities(request, res);
                    if (transactionEntities.Any())
                        await rawStockTransactionRepository.AddRangeAsync(transactionEntities);
                    if (insertStock is not null && insertStock.Count() > 0)
                        await _repository.AddRangeAsync(insertStock);
                    if (UpdateStock is not null && UpdateStock.Count() > 0)
                        await _repository.UpdateRangeAsync(UpdateStock);
                }

                scope.Complete();

                return new UpdateVm
                {
                    ResponseCode = "0",
                    ResponseMessage = "Success"
                };
            }

        }

        private async Task<BillingRawMaterial> ReverseBilling(UpdateCommand request)
        {


            var res = new BillingRawMaterial
            {
                ReverseBillingId=request.Id,
                BillImage = request.BillImage,
                BillNumber = request.BillNumber,
                Deleted = request.Deleted,
                Enabled = request.Enabled,
                TransactionType = TransactionType.Reverse,
                ClientId = request.ClientId,
                CreatedBy = request.CreatedBy,
                CreationDate = DateTime.Now,

            };
            var result = await billingRawMaterialRepository.AddAsync(res);
            return result;




        }
        private async Task<IEnumerable<RawStockInvoice>> ReverseInvoice(UpdateCommand request, BillingRawMaterial billingRawMaterial)
        {
            var insertRawStockInvoiceEntity = new List<RawStockInvoice>();
            foreach (var stock in request.stocks)
            {
                var rInvoiceTransaction = await this.rawStockInvoiceRepository.GetAsync(a => a.BillingId == request.Id && a.StockId == stock.StockId);
                foreach (var item in rInvoiceTransaction)
                {
                    insertRawStockInvoiceEntity.Add(new RawStockInvoice
                    {
                        BillingId = billingRawMaterial.Id,
                        ReverseBillingId = item.BillingId,
                        Deleted = item.Deleted,
                        Enabled = item.Enabled,
                        CreatedBy = item.CreatedBy,
                        CreationDate = DateTime.Now,
                        StockId = item.StockId
                    });
                }


            }
            var reverseResults = await rawStockInvoiceRepository.AddRangeAsync(insertRawStockInvoiceEntity);
            return reverseResults;
        }

        private async Task<(IEnumerable<RawStockTransaction> rowwStockTransaction, IEnumerable<AvialableRawMaterial> insert,
          IEnumerable<AvialableRawMaterial> update)> ReverseAailableEntities(UpdateCommand request, RawStockInvoice result)
        {
            // Create and return a list of RawStockTransaction entities based on the request and result
            var insertEntity = new List<AvialableRawMaterial>();
            var updateEntity = new List<AvialableRawMaterial>();
            var transactions = new List<RawStockTransaction>();

            var query = new GetQuery { Id = result.StockId };
            var stockMaster = await this.stockMasterRepository.GetDetails(query);
            int formula = stockMaster.details[0].stockCategory.CalculatePerPair;
            // var transactionsRequest = request.stocks.Where(w => w.StockId == result.StockId).SelectMany(s => s.transactions).ToList();
            var reverseInvoices = await rawStockInvoiceRepository.GetAsync(s => s.BillingId == result.ReverseBillingId && s.StockId == result.StockId);

            foreach (var item in reverseInvoices)
            {
                var transactionsRequest = await rawStockTransactionRepository.GetAsync(s => s.InvoiceId == item.Id);
                foreach (var transaction in transactionsRequest)
                {

                    transactions.Add(new RawStockTransaction
                    {
                        InvoiceId = result.Id,
                        ReverseInvoiceId = transaction.Id,
                        Amount = transaction.Amount,
                        ColorId = transaction.ColorId,
                        CreatedBy = result.CreatedBy,
                        Enabled = result.Enabled,
                        Deleted = result.Deleted,
                        MRP = transaction.MRP,
                        Quantity = -transaction.Quantity,
                        SizeId = transaction.SizeId,
                        TaxCGST = transaction.TaxCGST,
                        TaxSGST = transaction.TaxSGST,
                        CreationDate = result.CreationDate,
                        UpdatedBy = result.UpdatedBy,
                        UpdationDate = result.UpdationDate,

                    });

                    var entity = await this._repository.GetAsync(a => a.StockId == result.StockId && a.SizeId == transaction.SizeId && a.ColorId == transaction.ColorId);


                    var res = entity.FirstOrDefault();
                    if (res is not null)
                    {
                        res.ColorId = transaction.ColorId;
                        res.CreatedBy = result.CreatedBy;
                        res.Enabled = result.Enabled;
                        res.Deleted = result.Deleted;
                        res.StockId = result.StockId;
                        res.Quantity = (res.Quantity - (transaction.Quantity * formula));
                        res.ReverseQuantity = (res.ReverseQuantity is null ? 0: res.ReverseQuantity - (transaction.Quantity * formula));
                        res.SizeId = transaction.SizeId;
                        res.CreationDate = result.CreationDate;
                        res.UpdatedBy = result.UpdatedBy;
                        res.UpdationDate = result.UpdationDate;
                        updateEntity.Add(res);
                    }
                }

            }
            return (transactions, insertEntity, updateEntity);
        }

        private async Task<BillingRawMaterial> CreateBilling(UpdateCommand request)
        {


            var res = new BillingRawMaterial
            {

                BillImage = request.BillImage,
                BillNumber = request.BillNumber,
                Deleted = request.Deleted,
                Enabled = request.Enabled,
                TransactionType = request.TransactionType,
                ClientId = request.ClientId,
                CreatedBy = request.CreatedBy,
                CreationDate = DateTime.Now,

            };
            var result = await billingRawMaterialRepository.AddAsync(res);
            return result;




        }
        private async Task<IEnumerable<RawStockInvoice>> CreateInvoice(UpdateCommand request, BillingRawMaterial billingRawMaterial)
        {
            var insertRawStockInvoiceEntity = new List<RawStockInvoice>();
            foreach (var stock in request.stocks)
            {
                insertRawStockInvoiceEntity.Add(new RawStockInvoice
                {
                    BillingId = billingRawMaterial.Id,
                    Deleted = request.Deleted,
                    Enabled = request.Enabled,
                    CreatedBy = request.CreatedBy,
                    CreationDate = DateTime.Now,
                    StockId = stock.StockId
                });


            }
            var reverseResults = await rawStockInvoiceRepository.AddRangeAsync(insertRawStockInvoiceEntity);
            return reverseResults;
        }

        private async Task<(IEnumerable<RawStockTransaction> rowwStockTransaction, IEnumerable<AvialableRawMaterial> insert,
            IEnumerable<AvialableRawMaterial> update)> CreateAailableEntities(UpdateCommand request, RawStockInvoice result)
        {
            // Create and return a list of RawStockTransaction entities based on the request and result
            var insertEntity = new List<AvialableRawMaterial>();
            var updateEntity = new List<AvialableRawMaterial>();
            var transactions = new List<RawStockTransaction>();

            var query = new GetQuery { Id = result.StockId };
            var stockMaster = await this.stockMasterRepository.GetDetails(query);
            int formula = stockMaster.details[0].stockCategory.CalculatePerPair;
            var transactionsRequest = request.stocks.Where(w => w.StockId == result.StockId).SelectMany(s => s.transactions).ToList();
            foreach (var transaction in transactionsRequest)
            {
                transactions.Add(new RawStockTransaction
                {
                    InvoiceId = result.Id,
                    Amount = transaction.Amount,
                    ColorId = transaction.ColorId,
                    CreatedBy = result.CreatedBy,
                    Enabled = result.Enabled,
                    Deleted = result.Deleted,
                    MRP = transaction.MRP,
                    Quantity = transaction.Quantity,
                    SizeId = transaction.SizeId,
                    TaxCGST = transaction.TaxCGST,
                    TaxSGST = transaction.TaxSGST,
                    CreationDate = result.CreationDate,
                    UpdatedBy = result.UpdatedBy,
                    UpdationDate = result.UpdationDate,

                });
                var entity = await this._repository.GetAsync(a => a.StockId == result.StockId && a.SizeId == transaction.SizeId && a.ColorId == transaction.ColorId);

                if (entity != null && entity.Count < 1)
                {
                    insertEntity.Add(new AvialableRawMaterial
                    {
                        ColorId = transaction.ColorId,
                        CreatedBy = result.CreatedBy,
                        Enabled = result.Enabled,
                        Deleted = result.Deleted,
                        Quantity = (transaction.Quantity * formula),
                        SizeId = transaction.SizeId,
                        CreationDate = result.CreationDate,
                        UpdatedBy = result.UpdatedBy,
                        UpdationDate = result.UpdationDate,
                        StockId = result.StockId

                    });
                }
                else
                {
                    var res = entity.FirstOrDefault();
                    if (res is not null)
                    {
                        res.ColorId = transaction.ColorId;
                        res.CreatedBy = result.CreatedBy;
                        res.Enabled = result.Enabled;
                        res.Deleted = result.Deleted;
                        res.StockId = result.StockId;
                        res.Quantity = (res.Quantity + (transaction.Quantity * formula));
                    
                        res.SizeId = transaction.SizeId;
                        res.CreationDate = result.CreationDate;
                        res.UpdatedBy = result.UpdatedBy;
                        res.UpdationDate = result.UpdationDate;
                        updateEntity.Add(res);
                    }
                }
            }


            return (transactions, insertEntity, updateEntity);
        }


    }
}
