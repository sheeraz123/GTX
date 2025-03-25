using AutoMapper;
using Common.Miscellaneous;
using Common.Miscellaneous.Models;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using System.Transactions;
using User.Application.Contracts.Persistence;
using User.Domain.Entities;

namespace User.Application.Features.Stocks.AvailableRawStock.Command.Update
{
    public class UpdateHandler : IRequestHandler<UpdateCommand, UpdateVm>
    {
        private readonly IAvailableRawStockRepository _repository;
        private readonly IRawStockInvoiceRepository rawStockInvoiceRepository;

        private readonly IRawStockTransactionRepository rawStockTransactionRepository;
        private readonly IMapper _mapper;
        private readonly ImageServer _imageServer;

        public UpdateHandler(IAvailableRawStockRepository repository, IMapper mapper, IOptions<ImageServer> imageServer, IRawStockTransactionRepository rawStockTransactionRepository, IRawStockInvoiceRepository rawStockInvoiceRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _imageServer = imageServer.Value;
            this.rawStockTransactionRepository = rawStockTransactionRepository;
            this.rawStockInvoiceRepository = rawStockInvoiceRepository;
        }


        public async Task<UpdateVm> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var entity = _mapper.Map<RawStockInvoice>(request);
                var isExits = await rawStockInvoiceRepository.GetAsync(s => s.Id == entity.Id && s.BillNumber.ToLower() != entity.BillNumber.ToLower());

                if (isExits != null && isExits.Count > 0)
                {
                    return new UpdateVm()
                    {
                        ResponseCode = "-1",
                        ResponseMessage = "Record Already exists"
                    };
                }
                if (request.Image != null)
                {
                    var filePiath = await FileStorage.SaveFileAsync(request.Image, _imageServer.FileStoragePath, request.BillNumber);
                    entity.BillImage = Path.Combine(_imageServer.Path ?? "", request.BillNumber, request.Image.FileName);
                }

                var result = await rawStockInvoiceRepository.AddAsync(entity);
                // Create multiple transaction entities
                var (insertInvoice, UpdateInvoice) = await CreateTransactionEntities(request, result);
                if (insertInvoice != null)
                    await rawStockTransactionRepository.AddRangeAsync(insertInvoice);
                if (UpdateInvoice != null)
                    await rawStockTransactionRepository.UpdateRangeAsync(UpdateInvoice);

                var (insertStock, UpdateStock) = await CreateAailableEntities(request, result);
                if (insertStock != null)
                    await _repository.AddRangeAsync(insertStock);
                if (UpdateStock != null)
                    await _repository.UpdateRangeAsync(UpdateStock);
                scope.Complete();

                return _mapper.Map<UpdateVm>(result);
            }
        }
        private async Task<(IEnumerable<RawStockTransaction> insert, IEnumerable<RawStockTransaction> update)> CreateTransactionEntities(UpdateCommand request, RawStockInvoice result)
        {
            // Create and return a list of RawStockTransaction entities based on the request and result
            var insertEntity = new List<RawStockTransaction>();
            var updateEntity = new List<RawStockTransaction>();
            foreach (var transaction in request.transactions)
            {


                if (transaction.CartId != 0 && transaction.Id == 0)
                {
                    insertEntity.Add(new RawStockTransaction
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
                }
                else
                {
                    var entity = await this.rawStockTransactionRepository.GetAsync(a => a.Id == transaction.Id);
                    var res = entity.FirstOrDefault();
                    if (res is not null)
                    {
                        res.InvoiceId = result.Id;
                        res.Amount = transaction.Amount;
                        res.ColorId = transaction.ColorId;
                        res.CreatedBy = result.CreatedBy;
                        res.Enabled = result.Enabled;
                        res.Deleted = result.Deleted;
                        res.MRP = transaction.MRP;
                        res.Quantity = transaction.Quantity;
                        res.SizeId = transaction.SizeId;
                        res.TaxCGST = transaction.TaxCGST;
                        res.TaxSGST = transaction.TaxSGST;
                        res.CreationDate = result.CreationDate;
                        res.UpdatedBy = result.UpdatedBy;
                        res.UpdationDate = result.UpdationDate;
                        updateEntity.Add(res);
                    }
                }
            }
            return (insertEntity, updateEntity);
        }

        private async Task<(IEnumerable<AvialableRawMaterial> insert, IEnumerable<AvialableRawMaterial> update)> CreateAailableEntities(UpdateCommand request, RawStockInvoice result)
        {
            var insertEntity = new List<AvialableRawMaterial>();
            var updateEntity = new List<AvialableRawMaterial>();
            foreach (var transaction in request.transactions)
            {
                var entity = await this._repository.GetAsync(a => a.SizeId == transaction.SizeId && a.ColorId == transaction.ColorId);

                if (entity == null && entity.Count < 1)
                {
                    insertEntity.Add(new AvialableRawMaterial
                    {
                        ColorId = transaction.ColorId,
                        CreatedBy = result.CreatedBy,
                        Enabled = result.Enabled,
                        Deleted = result.Deleted,
                        Quantity = transaction.Quantity,
                        SizeId = transaction.SizeId,
                        CreationDate = result.CreationDate,
                        UpdatedBy = result.UpdatedBy,
                        UpdationDate = result.UpdationDate,

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
                        res.Quantity = transaction.Quantity;
                        res.SizeId = transaction.SizeId;
                        res.CreationDate = result.CreationDate;
                        res.UpdatedBy = result.UpdatedBy;
                        res.UpdationDate = result.UpdationDate;
                        updateEntity.Add(res);
                    }
                }
            }

            return (insertEntity, updateEntity);

        }
    }
}
