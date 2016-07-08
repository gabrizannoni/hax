using System;

namespace Hax.DeviceDrivers
{
    public interface IDriver
    {
        T CreateJob<T>();

        IJobCancellationToken Enqueue(ICommand command);
    }

    public interface IJobCancellationToken : IDisposable
    {
    }
}
