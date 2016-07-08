using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hax
{
    public interface IDeviceCommunication
    {
        void ReadOnce();

        void WriteOnce();

        ISubscription Subscribe();

        void SetAutomaticWrite(bool value);
    }

    public interface ISubscription : IDisposable
    {
    }
}
