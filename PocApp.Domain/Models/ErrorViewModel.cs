namespace PocApp.Domain.Models
{
    public class ErrorViewModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public int StatusCode { get; set; }
        public bool ShowHomeButton { get; set; } = true;
        public string RequestId { get; set; }
        public string StackTrace { get; set; }
    }
}
