using Common.Constant;
using Common.Contract.Messaging;
using Core.LIB;
using Newtonsoft.Json;
using System.Text;

namespace Core.Handler
{
    public class TryLoadBalanceHandler : RequestHandler<TryLoadBalanceReq, TryLoadBalanceResp>
    {
        private readonly IResponseFactory _responseFactory;
        public TryLoadBalanceHandler(IResponseFactory responseFactory) : base(responseFactory)
        {
            _responseFactory = responseFactory;
        }

        public override TryLoadBalanceResp Process(TryLoadBalanceReq req)
        {
            // Logic starts here.

            return new TryLoadBalanceResp();
        }

        
    }
}
