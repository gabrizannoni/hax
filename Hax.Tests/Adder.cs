using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hax.Connectors;

namespace Hax.Tests
{
    class Adder : BaseObject
    {
        public Adder(string name)
            : base(name)
        {
            Input1 = new BaseVariable("In1");
            HasConnector.Connect(this, Input1);
            Input1.SetValue(0);

            Input2 = new BaseVariable("In2");
            HasConnector.Connect(this, Input2);
            Input2.SetValue(0);

            Output = new BaseVariable("Out");
            HasConnector.Connect(this, Output);
            Output.SetValue(0);

            Input1.ValueChanged += (sender, args) => Calc();
            Input2.ValueChanged += (sender, args) => Calc();
        }

        public IVariable Input1 { get; }
        public IVariable Input2 { get; }
        public IVariable Output { get; }

        private void Calc()
        {
            var v1 = Input1.GetValue();
            var v2 = Input2.GetValue();

            var d1 = v1 == null ? 0.0 : Convert.ToDouble(v1);
            var d2 = v2 == null ? 0.0 : Convert.ToDouble(v2);

            Output.SetValue(d1 + d2);
        }
    }
}
