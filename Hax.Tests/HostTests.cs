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
    public class HostTests
    {
        [Test]
        public void AddRoot()
        {
            var host = new Host();

            var o1 = new BaseObject("O1");
            var o2 = new BaseObject("O2");

            host.AddRoot(o1);
            host.AddRoot(o2);

            Assert.That(host.Roots, Is.EquivalentTo(new [] {o1, o2}));
        }

        [Test]
        public void AddRootWithSameName()
        {
            var host = new Host();

            var o1 = new BaseObject("O1");
            var o2 = new BaseObject("O1");

            host.AddRoot(o1);
            Assert.That(() => host.AddRoot(o2), Throws.ArgumentException);
        }

        [Test]
        public void FindExisitingNode()
        {
            var host = new Host();

            var o1 = new BaseObject("O1");
            host.AddRoot(o1);
            /**/var o2 = new BaseObject("O12");
            /**/host.AddRoot(o2);
            /**/ContainsConnector.Connect(o1, o2);

            var o3 = new BaseObject("O3");
            host.AddRoot(o3);

            /****/var v1 = new BaseVariable("V1");
            /****/v1.SetValue(10);
            /****/HasConnector.Connect(o2, v1);

            /****/var v2 = new BaseVariable("V2");
            /****/v2.SetValue(20);
            /****/HasConnector.Connect(o2, v2);

            IVariable foundV1 = host.FindNode<IVariable>("/O1/O12/V1");
            Assert.That(foundV1, Is.SameAs(v1));

            IObject foundO3 = host.FindNode<IObject>("/O3");
            Assert.That(foundO3, Is.SameAs(o3));
        }

        [Test]
        public void FindNonExisitingNode()
        {
            var host = new Host();

            var o1 = new BaseObject("O1");
            host.AddRoot(o1);
            /**/var o2 = new BaseObject("O12");
            /**/host.AddRoot(o2);
            /**/ContainsConnector.Connect(o1, o2);

            var o3 = new BaseObject("O3");
            host.AddRoot(o3);

            /****/var v1 = new BaseVariable("V1");
            /****/v1.SetValue(10);
            /****/HasConnector.Connect(o2, v1);

            /****/var v2 = new BaseVariable("V2");
            /****/v2.SetValue(20);
            /****/HasConnector.Connect(o2, v2);

            INode found = host.FindNode("/O1/O3");
            Assert.That(found, Is.Null);
        }
    }
}
