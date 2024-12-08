
namespace Common.Contract
{
    public class Resp
    {
        public Resp()
        {
            Headers = new List<Header>();
            Success = true;
        }

        public IList<Header> Headers { get; set; }

        public bool Success { get; set; }

        public Error Error { get; set; }
    }
}
