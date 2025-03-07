namespace Common.Miscellaneous.Models
{
    public static class ResponseCodes
    {
        public static readonly  int Success = 3000;
        public static readonly int InvalidProgramNameordoesnotexists = 3001;
        public static readonly int ProgramNameisblank = 3002;
        public static readonly int InvalidSubProgramCodeordoesnotexist = 3003;
        public static readonly int SubProgramCodeisblank = 3004;
        public static readonly int DeliverToFullNameisblank = 3005;
        public static readonly int InvalidDeliverToFullNamecharacterlength = 3006;
        public static readonly int InvalidDeliverToFullNamevalue = 3007;
        public static readonly int DeliverToEmailAddressisblank = 3008;
        public static readonly int DeliverToEmailAddresscharacterlength = 3009;
        public static readonly int DeliverEmailAddressvalue = 3010;
        public static readonly int FirstNameisblank = 3011;
        public static readonly int InvalidFirstNamecharacterlength = 3012;
        public static readonly int InvalidFirstNamevalue = 3013;
        public static readonly int InvalidLastNameordoesnotexists = 3017;
        public static readonly int InvalidlastNamecharacterlength = 3018;
        public static readonly int InvalidlastNamevalue = 3019;
        public static readonly int DeliveryAddress1isblank = 3023;
        public static readonly int InvalidDeliveryAddress1characterlength = 3024;
        public static readonly int InvalidDeliveryAddress1value = 3025;
        public static readonly int Cityisblank = 3026;
        public static readonly int InvalidCityNamecharacterlength = 3027;
        public static readonly int InvalidCityvalue = 3028;
        public static readonly int Countryisblank = 3029;
        public static readonly int InvalidCountrycharacterlength = 3030;
        public static readonly int InvalidCountryvalueordoesnotexists = 3031;
        public static readonly int PostalCodeisblank = 3032;
        public static readonly int InvalidPostalcodecharacterlength = 3033;
        public static readonly int InvalidPostalCode = 3034;
        public static readonly int DeliverToContactphoneisblank = 3035;
        public static readonly int InvalidDeliverToContactPhonevalue = 3036;
        public static readonly int InvalidDeliverToContactPhonecharacterlength = 3037;
        public static readonly int RedemptionDateisblank = 3038;
        public static readonly int InvalidRedemptionDate = 3039;
        public static readonly int RedemptionDateisgreaterthantodaysdate = 3040;
        public static readonly int Redemptionconfirmationnumberisblank = 3041;
        public static readonly int InvalidRedemptionconfirmationnumber = 3042;
        public static readonly int DuplicateRedemptionconfirmationnumber = 3043;
        public static readonly int InvalidLineorderId = 3044;
        public static readonly int SKUisblank = 3045;
        public static readonly int SKUdoesntexist = 3046;
        public static readonly int InvalidSKUlength = 3047;
        public static readonly int RedemptionItemstatusisnotactive = 3048;
        public static readonly int RedemptionItemnotavailableintheexportedcatalogueatthedatetheitemwasredeemed = 3049;
        public static readonly int Quantityinblank = 3050;
        public static readonly int InvalidQuantityvaluelength = 3051;
        public static readonly int UnitItemPointsisempty = 3052;
        public static readonly int InvalidUnitItempointsvalueorlength = 3053;
        public static readonly int TotalItemPointsisempty = 3054;
        public static readonly int InvalidTotalItempointsvalue = 3055;
        public static readonly int AnymandatoryfieldDeliveryAddress2toDeliveryAddress4isblank = 3059;
        public static readonly int AnymandatoryfieldDeliveryAddress2toDeliveryAddress4hasinvalidcharacterlength = 3060;
        public static readonly int InvalidAnymandatoryfieldDeliveryAddress2toDeliveryAddress4 = 3061;
        public static readonly int UserIdIsBlank = 3067;
        public static readonly int InvalidUserIDvalueorcharacterlength = 3068;
        public static readonly int SubprogramCountrydoesnothavepublisheddata = 3069;
        public static readonly int Usernameisblank = 3070;
        public static readonly int InvalidUsernamevalueorcharacterlength = 3071;
        public static readonly int LineOrderIDisblank = 3072;
        public static readonly int invalidlengthorinvalidcharacters = 3072;
        public static readonly int RedemptionDatemustbegreaterthanpublisheddate = 3075;
        public static readonly int Stateisblank = 3088;
        public static readonly int InvalidStatecharacterlength = 3089;
        public static readonly int InvalidStatevalue = 3090;
        public static readonly int EitherAreaCodeorDirectPhoneisblank = 3091;
        public static readonly int InvalidcharacterlengthforeitherAreaCodeorDirectPhone = 3092;
        public static readonly int InvalidvalueforeitherAreaCodeorDirectPhone = 3093;
        public static readonly int InvalidOrderRemarksordoesnotexists = 3097;
        public static readonly int InvalidorderRemarkscharacterlength = 3098;
        public static readonly int SystemError = 3099;
        public static readonly int CountryISOcodeIsNull = 1004;
        public static readonly int Countshouldbegreaterthanzero = 1014;
        public static readonly int SortByisNull = 1015;
        public static readonly int SortByshouldonlycontainASCorDESC = 1020;
        public static readonly int InvalidItemKeyword = 3062;
        public static readonly int CatalogueSuccess = 1000;
        public static readonly int CatalogueNoRecordsFound = 1021;
        public static readonly int Subprogramcode = 1003;
        public static readonly int ProductStatusisblank = 1006;
        public static readonly int InvalidProductStatus = 1013;
        public static readonly int SortByColumnisnull = 1023;
        public static readonly int SortByColumnonlyallowedRedeemProductsorProductCategory = 1024;
        public static readonly int XSSDetected = 1017;
        public static readonly int Specialcharacternotallowed = 1018;
        public static readonly int OrderStatusisPendingTXwitherrormessagePartialsuccess = 3076;
        public static readonly int ERRedemeptionIDshouldbegreaterthanZero = 3073;
        public static readonly int NorecordsfoundOrder = 3074;
        public static readonly int RedemptionDateShouldNotlessthantwoPriorDate = 3077;
        public static readonly int OrderNoAndRedemptionIdOrUserIdStartDateandEndDate = 3078;
        public static readonly int StartDateIsBlank = 3079;
        public static readonly int InvalidDateFormat = 3080;
        public static readonly int EndDateIsBlank = 3081;
        public static readonly int EndDateShouldbeLessThanOrEqualToToday = 3082;

        //Inter API Error Code
        public static readonly string EmailTitelDoesNotExits = "-1001";
    }

    public static class ResponseMessages
    {
        public static readonly string Success = "success";
        public static readonly string NoRecordsFound = "No records Found";
    }

    public static class RewardsStatus
    {
        public static readonly string Active = "Active";

    }
}
