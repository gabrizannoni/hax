using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hax.DeviceDrivers
{
    public interface IReadCommand : ICommand
    {
        void Initialize(IReadCommandTarget target);
    }
}
