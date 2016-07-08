namespace Hax.DeviceDrivers
{
    public interface IWriteCommand : ICommand
    {
        void Initialize(IReadCommandTarget target, object proposedValue);
    }
}