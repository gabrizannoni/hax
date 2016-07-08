using System;

namespace Hax.DeviceDrivers
{
    public class CommandExceptionThrownEventArgs : EventArgs
    {
        public CommandExceptionThrownEventArgs(ICommand command, Exception exception)
        {
            Command = command;
            Exception = exception;
        }

        public ICommand Command { get; }

        public Exception Exception { get; }
    }
}