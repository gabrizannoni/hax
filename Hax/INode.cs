using System.Collections.Generic;

namespace Hax
{
    public interface INode
    {
        string Name { get; }

        IReadOnlyCollection<IConnector> In { get; }

        IReadOnlyCollection<IConnector> Out { get; }

        void AddConnector(IConnector connector);
        void RemoveConnector(IConnector connector);
    }
}