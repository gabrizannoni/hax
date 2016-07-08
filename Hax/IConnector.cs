using System.Collections.Generic;

namespace Hax
{
    public interface IConnector
    {
        INode Source { get; }
        INode Destination { get; }

        IEnumerable<IDeviceCommunication> GetDeviceCommunications();
    }
}