namespace Core.Integration
{
    public interface IPowerReaderEventService
    {
        Task EmitPowerReaderEvent(PowerReader powerReader);
    }
}