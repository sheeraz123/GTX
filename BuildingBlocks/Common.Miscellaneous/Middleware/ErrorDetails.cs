using System.Text.Json;

namespace Common.Miscellaneous.Middleware
{
    public class ErrorDetails
    {
        public int ResponseCode { get; set; }
        //[Newtonsoft.Json.JsonIgnore]
        
        //public string? Message { get; set; }
        //public string? SubProgramCode { get; set; }
        //public string? SKU { get; set; }
        //public string? OrderNo { get; set; }
        //public int? LineOrderId { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        //public DateTime? RedemptionDate { get; set; }
        //public int ERRedemeptionID { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
    public class InternalServerErrorDetails
    {
        public int ResponseCode { get; set; }
        //[Newtonsoft.Json.JsonIgnore]
        public string? Message { get; set; }
        
        //public string? SubProgramCode { get; set; }
        //public string? SKU { get; set; }
        //public string? OrderNo { get; set; }
        //public int? LineOrderId { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        //public DateTime? RedemptionDate { get; set; }
        //public int ERRedemeptionID { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
