namespace Hax.DeviceDrivers
{
    public interface ICommandScheduler
    {
        bool Enqueue(ICommand command);
    }
}