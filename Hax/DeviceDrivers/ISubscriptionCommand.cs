namespace Hax.DeviceDrivers
{
    public interface ISubscriptionCommand : ICommand
    {
        void Initialize(IReadCommandTarget target);
    }
}