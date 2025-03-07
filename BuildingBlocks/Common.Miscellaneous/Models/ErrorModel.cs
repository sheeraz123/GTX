using Newtonsoft.Json.Serialization;
using System.Runtime.Serialization;

namespace Common.Miscellaneous.Models
{
    public class ErrorModel
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Content { get; set; }
        [OnError]
        internal static void OnError(StreamingContext context, ErrorContext errorContext)
        {
            errorContext.Handled = true;
        }
    }
}
