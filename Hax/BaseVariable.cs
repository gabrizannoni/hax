using System;
using System.Collections.Generic;

namespace Hax
{
    public class BaseVariable : BaseNode, IVariable
    {
        private object _value;
        private ValueState _valueState;

        public BaseVariable(string name)
            : base(name)
        {
        }

        public event EventHandler ValueStateChanged;

        public event EventHandler ValueChanged;

        public ValueState ValueState
        {
            get { return _valueState; }
            private set
            {
                if (_valueState != value)
                {
                    _valueState = value;
                    OnValueStateChanged();
                }
            }
        }

        public object GetValue()
        {
            return _value;
        }

        public void SetValue(object value)
        {
            if (!Equals(_value, value))
            {
                _value = value;
                ValueState = ValueState.UpToDate;
                OnValueChanged();
            }
        }

        public IEnumerable<IDeviceCommunication> GetDeviceCommunications()
        {
            yield break;
        }

        protected virtual void OnValueStateChanged()
        {
            ValueStateChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnValueChanged()
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
