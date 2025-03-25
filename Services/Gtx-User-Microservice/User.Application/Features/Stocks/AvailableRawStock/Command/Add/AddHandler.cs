using AutoMapper;
using Common.Miscellaneous.Models;
using Common.Miscellaneous;
using MediatR;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;
using Microsoft.Extensions.Options;
using System.Transactions;
using System.Data.Common;
using User.Application.Features.Stocks.StockMasters.Query.GetData;

namespace User.Application.Features.Stocks.AvailableRawStock.Command.Add
{
    public class AddHandler : IRequestHandler<AddCommand, AddVm>
    {
        private readonly IAvailableRawStockRepository _repository;
        private readonly IRawStockInvoiceRepository rawStockInvoiceRepository;
        private readonly IRawStockTransactionRepository rawStockTransactionRepository;
        private readonly IStockMasterRepository stockMasterRepository;
        private readonly IMapper _mapper;
        private readonly ImageServer _imageServer;

        public AddHandler(IAvailableRawStockRepository repository, IMapper mapper, IOptions<ImageServer> imageServer, IRawStockTransactionRepository rawStockTransactionRepository, IRawStockInvoiceRepository rawStockInvoiceRepository, IStockMasterRepository stockMasterRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _imageServer = imageServer.Value;
            this.rawStockTransactionRepository = rawStockTransactionRepository;
            this.rawStockInvoiceRepository = rawStockInvoiceRepository;
            this.stockMasterRepository = stockMasterRepository;
        }

        public async Task<AddVm> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var entity = _mapper.Map<RawStockInvoice>(request);
                var isExits = await rawStockInvoiceRepository.GetAsync(s => s.BillNumber.ToLower() == entity.BillNumber.ToLower());

                if (isExits != null && isExits.Count > 0)
                {
                    return new AddVm()
                    {
                        ResponseCode = "-1",
                        ResponseMessage = "Record Already exists"
                    };
                }

                var entities = await CreateInvoice(request);

                var results = await rawStockInvoiceRepository.AddRangeAsync(entities);
                foreach (var res in results)
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

                return new AddVm
                {
                    ResponseCode = "0",
                    ResponseMessage = "Success"
                };
            }
        }
        private async Task<IEnumerable<RawStockInvoice>> CreateInvoice(AddCommand request)
        {
            var insertRawStockInvoiceEntity = new List<RawStockInvoice>();
            foreach (var stock in request.stocks)
            {
                insertRawStockInvoiceEntity.Add(new RawStockInvoice
                {
                    BillImage = request.BillImage,
                    BillNumber = request.BillNumber,
                    Deleted = request.Deleted,
                    Enabled = request.Enabled,
                    TransactionType = request.TransactionType,
                    ClientId = request.ClientId,
                    CreatedBy = request.CreatedBy,
                    CreationDate = DateTime.Now,
                    StockId = stock.StockId
                });


            }
            return insertRawStockInvoiceEntity;
        }


        private async Task<(IEnumerable<RawStockTransaction> rowwStockTransaction, IEnumerable<AvialableRawMaterial> insert, IEnumerable<AvialableRawMaterial> update)> CreateAailableEntities(AddCommand request, RawStockInvoice result)
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
                        res.Quantity = result.TransactionType == TransactionType.Earn ? (res.Quantity + (transaction.Quantity * formula)) : (res.Quantity - (transaction.Quantity * formula));
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
