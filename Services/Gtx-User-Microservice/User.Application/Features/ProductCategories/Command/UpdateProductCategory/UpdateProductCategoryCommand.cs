using MediatR;
using User.Application.Features.ProductCategories.Command.AddProductCategory;

public class UpdateProductCategoryCommand : IRequest<UpdateProductCategoryVm>
{
    public required int id { get; set; }
    public required string ProductCategoryName { get; set; }
    public required string CategoryCode { get; set; }
    public required bool Enabled { get; set; }
    public required bool Deleted { get; set; }
    public required decimal CreatedBy { get; set; }
    public required decimal UpdatedBy { get; set; }
}