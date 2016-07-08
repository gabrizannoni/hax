using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hax
{
    public class StagedVariable : BaseNode, IVariable
    {
        private readonly IValueStage _valueStageChain;

        public StagedVariable(string name, IValueStage valueStageChain)
            : base(name)
        {
            _valueStageChain = valueStageChain;

            _valueStageChain.ValueStateChanged += (sender, args) => OnValueStateChanged();
            _valueStageChain.ValueChanged += (sender, args) => OnValueChanged();
        }

        public event EventHandler ValueStateChanged;

        public event EventHandler ValueChanged;

        public ValueState ValueState => _valueStageChain.ValueState;

        public object GetValue()
        {
            return _valueStageChain.GetValue();
        }

        public void SetValue(object value)
        {
            _valueStageChain.SetValue(value);
        }

        public IEnumerable<IDeviceCommunication> GetDeviceCommunications()
        {
            // Refactor value chain to be searchable?
            throw new NotImplementedException();
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
