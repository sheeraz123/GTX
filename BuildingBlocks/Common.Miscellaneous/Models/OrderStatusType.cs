namespace Common.Miscellaneous.Models
{
    public static class OrderStatusType
    {
        public static readonly string Redeemed = "Redeemed";
        public static readonly string Delivered = "Delivered";
        public static readonly string PendingTX = "Pending-TX";
    }
    public static class ExportFlags
    {
        public static readonly char R = 'R';
        public static readonly char N = 'N';
        public static readonly char D = 'D';
    }

    public static class SendVoucherType
    {
        public static readonly string OperationCodeSend = "SendVoucherIdempotent";
    }

    public static class DefaultValues
    {
        public static readonly string DeliverAddress1 = "Default Address1";
        public static readonly string DeliverAddress2 = "Default Address2";
        public static readonly string City = "Default City";
        public static readonly string State = "Default State";
        public static readonly string PostalCode = "000000";
        public static readonly long UnitProductPoints = 1;
        public static readonly long TotalProductPoints = 1;
        public static readonly string OrderRemarks = "NULL";
    }
    public static class ItemKeyword
    {
        public static readonly string VoucherDigitalGR = "VOUCHERDIGITALGR";
        public static readonly string VoucherDigital = "VOUCHERDIGITAL";
        public static readonly string NonVoucher = "NONVOUCHER";
        public static readonly string VoucherDigitalER = "VOUCHERDIGITALER";
        public static readonly string VoucherPhysicalER = "VOUCHERPHYSICALER";
    }


}
