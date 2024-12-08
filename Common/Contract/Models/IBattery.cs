namespace Common.Contract.Models;

public interface IBattery
{
    int MaxDischargePower();
    int MaxChargePower();
    int GetBatteryPercent();
    int GetCurrentPower();
    bool IsBusy();
    Task SetNewPower(int newPower);
}
