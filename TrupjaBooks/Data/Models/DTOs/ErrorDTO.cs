using Newtonsoft.Json;

namespace TrupjaBooks.Data.Models.DTOs
{
    public class ErrorDTO
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
