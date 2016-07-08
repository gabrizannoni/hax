using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hax.ValueStages
{
    public class FieldValueStage : IValueStage
    {
        private object _value;
        private ValueState _valueState;
        private IVariable _variable;

        public FieldValueStage(IVariable variable)
        {
            _variable = variable;
        }

        public event EventHandler ValueStateChanged;

        public event EventHandler ValueChanged;

        public ValueState ValueState
        {
            get { return _valueState; }
            private set
            {
                _valueState = value;
                OnValueStateChanged();
            }
        }

        public object GetValue()
        {
            return _value;
        }

        public void SetValue(object value)
        {
            _value = value;
            OnValueChanged();
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
