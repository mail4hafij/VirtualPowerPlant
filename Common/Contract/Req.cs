
namespace Common.Contract
{
    public abstract class Req
    {
        protected Req()
        {
            Headers = new List<Header>();
        }

        public IList<Header> Headers { get; set; }
    }
}
