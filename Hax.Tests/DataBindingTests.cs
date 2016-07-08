using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hax.Connectors;
using NUnit.Framework;

namespace Hax.Tests
{
    [TestFixture]
    public class DataBindingTests
    {

        [Test]
        public void Binding()
        {
            var v1 = new BaseVariable("V1");
            var v2 = new BaseVariable("V2");

            DataBindConnector.Connect(v1, v2);

            v1.SetValue("Hello!");

            Assert.That(v2.GetValue(), Is.EqualTo("Hello!"));
        }

        [Test]
        public void ComplexBinding()
        {
            var adder = new Adder("Adder");

            var v1 = new BaseVariable("V1");
            var v2 = new BaseVariable("V2");

            DataBindConnector.Connect(v1, adder.Input1);
            DataBindConnector.Connect(v2, adder.Input2);

            v1.SetValue(10.0);
            Assert.That(adder.Output.GetValue(), Is.EqualTo(10.0));

            v2.SetValue(20.0);
            Assert.That(adder.Output.GetValue(), Is.EqualTo(30.0));
        }
    }
}
