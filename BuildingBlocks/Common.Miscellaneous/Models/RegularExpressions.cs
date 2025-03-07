namespace Common.Miscellaneous.Models
{
    public static class RegularExpressions
    {
        public static readonly string allowCharacters = "^[a-zA-Z]+$";
        public static readonly string allowCharactersWithSpaces = "^[a-zA-Z0-9_ ]*$";
        public static readonly char[] programName = new char[] { '`', '~', '#', '$', '%', '^', '&', '*', '=', '+', '[', '{', '}', '|', '!', '"', '\\', '>', '<', '?', '"' };
        public static readonly char[] username = new char[] { '`', '<', '>', ';', '+', '~', '#', '{', '}', '|', '?', '%', '!', '*', '^', '\'', '"', '=', '/', '\\' };
        public static readonly char[] firstName = new char[] { '`', '>', '<', ';', '+', '~', '#', '{', '}', '|', '?', '%', '!', '*', '^', '"', '=', '@', '/', '\\', '[', ']' };
        public static readonly char[] lastName = new char[] { '`', '>', '<', ';', '+', '~', '#', '{', '}', '|', '?', '%', '!', '*', '^', '"', '=', '@', '/', '\\', '[', ']' };
        public static readonly char[] fullName = new char[] { '`', '>', '<', ';', '+', '~', '#', '{', '}', '|', '?', '%', '!', '*', '^', '"', '=', '@', '/', '\\', '[', ']' };
        public static readonly char[] email = new char[] { '`', '~', '#', '$', '%', '^', '&', '*', '(', ')', '=', '+', '[', ']', '\\', '{', '}', '|', ';', '!', '\'', ':', ',', '/', '<', '>', '"', '?' };
        public static readonly string validEmail = "^([a-zA-Z0-9])+([\\.a-zA-Z0-9_-])*@([a-zA-Z0-9-])+(\\.[a-zA-Z0-9_-]+)+$";

        public static readonly char[] address1 = new char[] { '!', '^', '{', '}', '+', '>', '<', '?', '|', '/', '<', '>' };
        public static readonly char[] address2 = new char[] { '!', '^', '{', '}', '+', '>', '<', '?', '|', '/', '<', '>' };
        public static readonly char[] address3 = new char[] { '!', '^', '{', '}', '+', '>', '<', '?', '|', '/', '<', '>' };
        public static readonly char[] address4 = new char[] { '!', '^', '{', '}', '+', '>', '<', '?', '|', '/', '<', '>' };
        public static readonly char[] city = new char[] { '`', '>', '<', ';', '+', '~', '#', '{', '}', '|', '?', '%', '!', '*', '^', '=', '@', '(', ')', '/', '\\', '"', '&', '\'' };
        public static readonly char[] state = new char[] { '`', '>', '<', ';', '+', '~', '#', '{', '}', '|', '?', '%', '!', '*', '^', '=', '@', '(', ')', '/', '\\', '"', '&', '\'' };
        public static readonly string country = "^[A-Za-z]";
        public static readonly char[] postalCode = new char[] { '`', '~', '#', '$', '%', '^', '&', '*', '=', '+', '[', '{', '}', '|', '!', '"', '\\', '>', '<', '?', '"', '/' };
        public static readonly string areaCode = "^[0-9]+$";
        public static readonly char[] deliverToContactPhone = new char[] { '`', '~', '@', '$', '%', '^', '&', '*', '=', '{', '}', '|', ';', '!', '\'', '>', '<', '?', '"', '=', '/', '\\', '[', ']' ,'+'};
        public static readonly string validDeliverToContactPhone = "[0-9]";
        public static readonly string redemptionDate = ": ~!@#$%^&*()_+-=`[]\\{}|;':\"<>,. A-z";
        public static readonly char[] orderNumber = new char[] { '`', '>', '<', ';', '+', '~', '#', '{', '}', '|', '?', '%', '!', '*', '^', '=', '@', '(', ')', '/', '\\', '"' };
        public static readonly char[] productName = new char[] { '<', '/', '>' };
        public static readonly string sku = "[a-zA-Z0-9_]+$";
        public static readonly string quantity = "[0-9]";
        public static readonly char[] userId = new char[] { '`', '<', '>', ';', '+', '~', '#', '{', '}', '|', '?', '%', '!', '*', '^', '\'', '"', '=', '/', '\\' };
        public static readonly string directPhone = "^[0-9]";
        public static readonly string unitItemPoint = "[0-9]";
        public static readonly string totalItemPoint = "[0-9]";
        public static readonly char[] OrderRemarks = new char[] { '~', '{', '}', '/', '>', '"' };

    }
    public static class DateFormatType
    {
        public static readonly string yyyyMMdd = "yyyy-MM-dd";
    }
}
