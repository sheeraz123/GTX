using MediatR;
using Microsoft.AspNetCore.Http;

namespace User.Application.Features.ProductMasters.Command.UpdateProductMaster
{
    public class UpdateProductMasterCommand : IRequest<UpdateProductMasterVm>
    {
        public required decimal Id { get; set; }
        public required string ProductName { get; set; }
        public required string ProductDescription { get; set; }
        public required string ProductCode { get; set; }
        public required string ProductImage { get; set; }
        public  IFormFile? Image { get; set; }
        public required string HSNCode { get; set; }
        public required decimal MRP { get; set; }
        public int ProductCategoryId { get; set; }
        public required decimal CreatedBy { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }

        public required decimal UpdatedBy { get; set; }
      
    }
}


