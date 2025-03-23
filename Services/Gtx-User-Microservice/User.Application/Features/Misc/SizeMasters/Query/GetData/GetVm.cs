using Common.Miscellaneous.Models;

namespace User.Application.Features.Misc.SizeMasters.Query.GetData
{
     public class GetVm : BaseResponse
    {
        public int TotalRecords { get; set; }
        public IReadOnlyList<GetDetailsVm>? Details { get; set; }
    }
    public class GetDetailsVm 
    {
        public decimal Id { get; set; }
        public required int Size { get; set; }
        public string? SizeType { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public required bool Enabled { get; set; } = true;
        public required bool Deleted { get; set; } = false;
        public decimal? CreatedBy { get; set; }
        public decimal? UpdatedBy { get; set; }

    }
}
