namespace Common.Miscellaneous.Models
{
    public class EmailSendRequestVM
    {
        public EmailSendRequestVM(int? subProgramID, int? countryID, int? memberID, string from, string to, string? cC, string? bCC, string subject, string content, string? displayName, string? title, DateTime creationDate)
        {
            SubProgramID = subProgramID;
            CountryID = countryID;
            MemberID = memberID;
            From = from;
            To = to;
            CC = cC;
            BCC = bCC;
            Subject = subject;
            Content = content;
            DisplayName = displayName;
            Title = title;
            CreationDate = creationDate;
        }

        public int? SubProgramID { get; set; }
        public int? CountryID { get; set; }
        public int? MemberID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string? CC { get; set; }
        public string? BCC { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string? DisplayName { get; set; }
        public string? Title { get; set; }
        public DateTime? CreationDate { get; set; } 
    }
}
