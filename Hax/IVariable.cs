using System;
using System.Collections;
using System.Collections.Generic;

namespace Hax
{
    public interface IVariable : INode
    {
        event EventHandler ValueStateChanged;

        event EventHandler ValueChanged;

        ValueState ValueState { get; }
        
        object GetValue();

        void SetValue(object value);

        IEnumerable<IDeviceCommunication> GetDeviceCommunications();
    }
}