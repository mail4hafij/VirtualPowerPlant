namespace Core.Business.Models;
using Common.Contract.Models;

public class Battery : IBattery
{
    private int _currentPower = 0;
    private bool _isBusy;
    private double _batteryPercent = 50;
    private readonly int _maxChargePower;
    private readonly int _maxDischargePower;

    public Battery()
    {
        _maxChargePower = (int)Random.Shared.Next(100, 110);
        _maxDischargePower = (int)Random.Shared.Next(100, 110);

        _ = UpdateSoC();
    }

    /// <summary>
    /// Sets the battery to charge (positive values) or discharge (negative values).
    /// </summary>
    /// <param name="newPower">How many watts the battery should charge/discharge</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public async Task SetNewPower(int newPower)
    {
        if (newPower > _maxChargePower)
        {
            throw new ArgumentOutOfRangeException(nameof(newPower));
        }

        if (newPower < -_maxDischargePower)
        {
            throw new ArgumentOutOfRangeException(nameof(newPower));
        }

        if (_isBusy)
        {
            throw new ArgumentException("Battery is busy");
        }

        _isBusy = true;
        await Task.Delay(TimeSpan.FromMilliseconds(Random.Shared.Next(500, 2500)));
        _currentPower = newPower;
        _isBusy = false;
    }

    /// <summary>
    /// Returns the current amount of watts the battery charges/dischages.
    /// </summary>
    /// <returns></returns>
    public int GetCurrentPower()
    {
        if (_currentPower > 0 && _batteryPercent >= 100)
        {
            return 0;
        }
        if (_currentPower < 0 && _batteryPercent <= 0)
        {
            return 0;
        }
        return _currentPower;
    }

    public bool IsBusy() => _isBusy;
    public int MaxChargePower() => _maxChargePower;
    public int MaxDischargePower() => _maxDischargePower;

    /// <summary>
    /// Returns how much the battery is charged. If it is 0% the battery is empty, and 100% it's full.
    /// If the battery is empty, it cannot discharge more. And if it's 100% it cannot charge more.
    /// </summary>
    /// <returns>The percentage of charge the battery can have.</returns>
    public int GetBatteryPercent()
    {
        return (int)_batteryPercent;
    }

    private async Task UpdateSoC()
    {
        while (true)
        {
            if (_currentPower > 0 && _batteryPercent < 100)
            {
                // charge is not symetric with discharge
                _batteryPercent += (double)_currentPower / 1200;
            }

            if (_currentPower < 0 && _batteryPercent > 0)
            {
                _batteryPercent += (double)_currentPower / 1000;
            }

            await Task.Delay(1000);
        }
    }
}