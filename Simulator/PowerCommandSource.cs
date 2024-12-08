namespace Emulator;
using Core.Integration;

/// <summary>
/// This class sends out a stream of events with the currently requested power.
/// </summary>
public class PowerCommandSource
{
    private readonly IPowerReaderEventService _powerReaderEventService;
    public int Magnitude { get; private set; }

    // Let's not initialize the callback to any default
    private Action<int> _callback;
    
    private const int MaxPower = 1000;

    public PowerCommandSource(IPowerReaderEventService powerReaderEventService)
    {
        _powerReaderEventService = powerReaderEventService;
        _ = RunGenerator();
    }

    /// <summary>
    /// Set a loadbalancer to handle the currently requested power. 
    /// </summary>
    /// <param name="callback">The callback to be called.</param>
    public void SetLoadBalancer(Action<int> callback) => _callback = callback;

    private async Task RunGenerator()
    {
        var generatorType = Random.Shared.Next(0, 2);
        Func<int, int> generator = generatorType switch
        {
            1 => _sineGenerator,
            _ => _squareGenerator
        };

        for (var second = 0; ; second++)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            try
            {
                Magnitude = generator(second);
                
                // Way 2
                // Emit event to azure service bus
                // Comment out the following line to emit events to AzureServiceBus Queue
                /*
                await _powerReaderEventService.EmitPowerReaderEvent(new PowerReader()
                {
                    BatteryPoolId = 1, // some dummy id to indicate which batterypool to balance
                    Magnitude = Magnitude
                });
                */

                // Callback for load balance
                if(_callback != null)
                {
                    _ = Task.Run(() => _callback.Invoke(Magnitude));
                }

                Console.WriteLine($"Current requested power: {Magnitude}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("PowerCommandSource failed, it shouldn't");
                Console.Error.WriteLine(ex.ToString());
                Environment.Exit(1);
            }
        }
    }

    private readonly Func<int, int> _sineGenerator = second =>
    {
        var angle = (double)second * 5 / 360 * 2 * Math.PI;
        var magnitude = Math.Sin(angle) * MaxPower;
        return (int)magnitude;
    };

    private readonly Func<int, int> _squareGenerator = second => (second % 10 < 5) ? MaxPower : -MaxPower;
}