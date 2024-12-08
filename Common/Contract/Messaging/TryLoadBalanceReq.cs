using Common.Constant;

namespace Common.Contract.Messaging
{
    public class TryLoadBalanceReq : Req
    {
        public int BatteryPoolId { get; set; }
        public int Magnitude { get; set; }
        public string Method { get; set; } = Values.Methods.Greedy.ToString();
    }
}
