using MediatR;

namespace User.Application.Features.ProductCategories.Command.AddProductCategory
{
    public class AddProductCategoryCommand : IRequest<AddProductCategoryVm>
    {
        public string ProductCategoryName { get; set; }
        public string? CategoryCode { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public required decimal CreatedBy { get; set; }
    }
}
