namespace Core.Business;
using Common.Contract.Models;

public class LoadBalancer : ILoadBalancer
{
    private readonly IBatteryPool _pool;

    public LoadBalancer(IBatteryPool pool)
    {
        _pool = pool;
    }

    public async void TryGreedyBalance(int requestedPower)
    {
        // ASSUMPTION 1 (maybe it is wrong. maybe it is upside down)
        // positive power means - we need to charge the battery pool
        // negetive power means - we need to discharge the battery pool

        // ASSUMPTION 2
        // positive power means - we need to discharge the battery pool to supply power to VPP.
        // negetive power means - we need to charge the battery pool since the negetive demand in the VPP.

        // Going with assumption 2
        requestedPower = -1 * requestedPower;

        if (requestedPower < 0)
        {
            // discharge
            foreach (var battery in _pool.GetConnectedBatteries().OrderByDescending(b => b.GetBatteryPercent()))
            {
                // sort - batteries with most percentage.
                if (battery.GetBatteryPercent() > 0 && requestedPower < 0)
                {
                    if (requestedPower < -battery.MaxDischargePower() && !battery.IsBusy())
                    {
                        // -1000 < -100
                        await battery.SetNewPower(-battery.MaxDischargePower());
                        requestedPower = requestedPower - (-battery.MaxDischargePower());
                    }
                    else if (requestedPower > -battery.MaxDischargePower() && !battery.IsBusy())
                    {
                        // -50 > -100
                        await battery.SetNewPower(requestedPower);
                        requestedPower = 0;
                    }
                }
            }
        }
        else if (requestedPower > 0)
        {
            // charge
            foreach (var battery in _pool.GetConnectedBatteries().OrderBy(b => b.GetBatteryPercent()))
            {
                // sort - batteries with less percentage
                if (battery.GetBatteryPercent() < 100 && requestedPower > 0)
                {
                    if (requestedPower > battery.MaxChargePower() && !battery.IsBusy())
                    {
                        // 1000 > 100
                        await battery.SetNewPower(battery.MaxChargePower());
                        requestedPower = requestedPower - battery.MaxChargePower();
                    }
                    else if (requestedPower < battery.MaxChargePower() && !battery.IsBusy())
                    {
                        // 50 < 100
                        await battery.SetNewPower(requestedPower);
                        requestedPower = 0;
                    }
                }
            }
        }
    }

    public async void TryProportionalBalance(int requestedPower)
    {
        throw new NotImplementedException();
    }
}

