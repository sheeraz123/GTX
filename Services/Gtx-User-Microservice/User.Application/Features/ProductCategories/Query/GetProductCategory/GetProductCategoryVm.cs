using Common.Miscellaneous.Models;

namespace User.Application.Features.ProductCategories.Query.GetProductCategory
{
     public class GetProductCategoryVm : BaseResponse
    {
        public int TotalRecords { get; set; }
        public IReadOnlyList<GetProductCategoryDetailsVm>? Details { get; set; }
    }
    public class GetProductCategoryDetailsVm
    {
        public int Id { get; set; }
        public required string ProductCategoryName { get; set; }
        public string? CategoryCode { get; set; }
        public DateTime CreationDate { get; set; } 
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } 
        public required bool Deleted { get; set; } 
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }
    }
}
