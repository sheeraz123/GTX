using Common.Miscellaneous.Models;
using User.Application.Features.ClientMasters.Query;

namespace User.Application.Features.ProductMasters.Query.GetProductMaster
{
    public class GetProductMasterVm : BaseResponse
    {
        public int TotalRecords { get; set; }
        public IReadOnlyList<GetProductMasterDetailsVm>? Details { get; set; }
    }
    public class GetProductMasterDetailsVm
    {
        public decimal Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductCode { get; set; }

        public string? HSNCode { get; set; }
        public decimal MRP { get; set; }
        public decimal ProductCategoryId { get; set; }
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }
        public bool Enabled { get; set; } 
        public bool Deleted { get; set; }  
        public DateTime CreationDate { get; set; } 
        public DateTime? UpdationDate { get; set; }
        public User.Domain.Entities.ProductCategory?  productCategory{ get; set; }
        public string? ProductImage { get; set; }
    }
}


