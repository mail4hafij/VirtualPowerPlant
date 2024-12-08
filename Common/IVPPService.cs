using Common.Contract.Messaging;

namespace Common
{
    public interface IVPPService
    {
        TryLoadBalanceResp TryLoadBalance(TryLoadBalanceReq req);
    }
}
