using System;
using Hax.DeviceDrivers;

namespace Hax.ValueStages
{
    public abstract class DeviceValueStage : IValueStage, IReadCommandTarget
    {
        private object _committedValue;
        private readonly IDriver _driver;

        protected DeviceValueStage(IDriver driver)
        {
            _driver = driver;
        }

        public event EventHandler ValueStateChanged;

        public event EventHandler ValueChanged;

        public ValueState ValueState { get; protected set; }

        public object GetValue()
        {
            return _committedValue;
        }

        public void SetValue(object value)
        {
            var writeJob = _driver.CreateJob<IWriteCommand>();
            writeJob.Initialize(this, value);

            ValueState = ValueState.Writing;
            OnValueStateChanged();

            _driver.Enqueue(writeJob);
        }

        protected virtual void OnValueStateChanged()
        {
            ValueStateChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnValueChanged()
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }

        public void SetCommittedValue(object value)
        {
            _committedValue = value;
            ValueState = ValueState.UpToDate;
            OnValueChanged();
            OnValueStateChanged();
        }
    }
}
