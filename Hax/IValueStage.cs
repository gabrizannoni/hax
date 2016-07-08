using System;

namespace Hax
{
    public interface IValueStage
    {
        event EventHandler ValueStateChanged;

        event EventHandler ValueChanged;

        ValueState ValueState { get; }

        object GetValue();

        void SetValue(object value);
    }
}