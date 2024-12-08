using Common;
using Common.Contract.Messaging;
using Core.LIB;

namespace Core
{
    public class VPPService : HandlerBase, IVPPService
    {
        public VPPService(IHandlerCaller handlerCaller) : base(handlerCaller) { }

        public TryLoadBalanceResp TryLoadBalance(TryLoadBalanceReq req) => Process<TryLoadBalanceReq, TryLoadBalanceResp>(req);
    }
}
