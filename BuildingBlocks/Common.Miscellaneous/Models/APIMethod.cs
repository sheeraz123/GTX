namespace Common.Miscellaneous.Models
{
    public static class ApiMethod
    {
        public static readonly string getProgramMaster = "api/v1/BaseProgramMaster?";
        public static readonly string getProgramData = "api/v1/GetProgramData/";
        public static readonly string GetCountryByNameAndISOCode = "api/v1/GetCountryISOCode/";
        public static readonly string GetProgramCountryById = "api/v1/GetProgramCountryById/";
        public static readonly string GetSubProgramMaster = "api/v1/GetBaseSubProgramMasters/";
        public static readonly string GetPublishedItem = "api/v1/GetPublishedItem/";
        public static readonly string GetSendVoucher = "api/SendVoucher/GetSendVoucher";
        public static readonly string GetVoucherConfiguration = "api/v1/GetVoucherConfiguration/";
        public static readonly string GetRedeemedOrderCount = "api/v1/GetMostRedeemedProductSum";
        public static readonly string GetProgramCatalogueItem = "api/v1/GetProgramCatalogueItem/";
        public static readonly string GetEmailContent = "api/v1/EmailContent/";
        public static readonly string SendEmailScheduler = "api/v1/scheduler/sendemail";
    }
}
