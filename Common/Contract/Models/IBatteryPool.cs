namespace Common.Contract.Models;

public interface IBatteryPool
{
    IList<IBattery> GetConnectedBatteries();
}
