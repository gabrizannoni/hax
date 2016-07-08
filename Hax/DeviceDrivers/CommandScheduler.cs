using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Hax.DeviceDrivers
{
    public class CommandScheduler : ICommandScheduler
    {
        private readonly TimeSpan _enqueueTimeout;
        private Thread _thread;
        private readonly BlockingCollection<ICommand> _jobs;

        public CommandScheduler(int maxQueueSize, TimeSpan enqueueTimeout)
        {
            _enqueueTimeout = enqueueTimeout;
            _jobs = new BlockingCollection<ICommand>(maxQueueSize);
        }

        public event EventHandler<CommandExceptionThrownEventArgs> JobExceptionThrown;

        public void Start()
        {
            if (_thread != null)
                return;

            _thread = new Thread(Loop);
            _thread.Start();
        }

        public void Stop()
        {
            if (_thread == null)
                return;

            _jobs.CompleteAdding();
            _thread.Join();
        }

        public bool Enqueue(ICommand command)
        {
            return _jobs.TryAdd(command, _enqueueTimeout);
        }

        private void Loop()
        {
            while (!_jobs.IsCompleted)
            {
                var job = _jobs.Take();
                
                RunJob(job);
            }
        }

        private void RunJob(ICommand command)
        {
            try
            {
                command.Run();
            }
            catch (Exception e)
            {
                var eventArgs = new CommandExceptionThrownEventArgs(command, e);
                OnJobExceptionThrown(eventArgs);
            }
        }

        protected virtual void OnJobExceptionThrown(CommandExceptionThrownEventArgs e)
        {
            JobExceptionThrown?.Invoke(this, e);
        }
    }
}
