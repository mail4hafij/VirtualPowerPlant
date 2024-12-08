using Common.Constant;

namespace Common.Contract.Forms
{
    public class TryLoadBalanceForm
    {
        public int BatteryPoolId { get; set; }
        public int Magnitude {  get; set; }
        public string Method { get; set; } = Values.Methods.Greedy.ToString();
    }
}
