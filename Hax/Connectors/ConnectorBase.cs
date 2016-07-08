using System.Collections.Generic;

namespace Hax.Connectors
{
    public abstract class ConnectorBase : IConnector
    {
        protected static void AddConnectorToSourceAndDestination(ConnectorBase connector)
        {
            connector.Source.AddConnector(connector);
            connector.Destination.AddConnector(connector);
        }

        protected ConnectorBase(INode source, INode destination)
        {
            Source = source;
            Destination = destination;
        }

        public INode Source { get; }

        public INode Destination { get; }

        public virtual IEnumerable<IDeviceCommunication> GetDeviceCommunications()
        {
            yield break;
        }
    }
}