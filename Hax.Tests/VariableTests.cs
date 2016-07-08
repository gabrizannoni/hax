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
    public class VariableTests
    {
        [Test]
        public void Ctor()
        {
            var v = new BaseVariable("Name");

            Assert.That(v.Name, Is.EqualTo("Name"));
            Assert.That(v.GetValue(), Is.Null);
        }

        [Test]
        public void WriteAndRead()
        {
            var v = new BaseVariable("Name");

            v.SetValue(5);
            Assert.That(v.GetValue(), Is.EqualTo(5));
        }

        [Test]
        public void VariableChangedOnWrite()
        {
            var v = new BaseVariable("Name");
            int value = 0;
            v.ValueChanged += (sender, args) => value = (int) v.GetValue();
            v.SetValue(5);
            Assert.That(value, Is.EqualTo(5));
        }
    }
}
