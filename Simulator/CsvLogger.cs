using Emulator;
using Core.Business.Models;
using System.Diagnostics;

/// <summary>
/// This class monitors the current requested power, and the current output power.
/// It writes the values every second to a temp file you can read later. 
/// </summary>
internal class CsvLogger
{
    private readonly BatteryPool pool;
    private readonly PowerCommandSource source;
    private readonly string fileName;

    public CsvLogger(BatteryPool pool, PowerCommandSource source)
    {
        this.pool = pool;
        this.source = source;
        this.fileName = Path.GetTempFileName() + ".csv";
        Console.WriteLine($"Logging to {fileName}");
        var logLine = $"Time;Target;Output";
        File.AppendAllLines(fileName, new[] { logLine });

        _ = Task.Run(StartLogger);
    }

    private async void StartLogger()
    {
        var sw = Stopwatch.StartNew();
        while (true)
        {
            var actualOutput = pool.GetConnectedBatteries().Sum(battery => battery.GetCurrentPower());
            var requestedPower = source.Magnitude;
            var logLine = $"{sw.Elapsed};{requestedPower};{actualOutput}";
            File.AppendAllLines(fileName, new[] { logLine });
            await Task.Delay(100);
        }
    }
}