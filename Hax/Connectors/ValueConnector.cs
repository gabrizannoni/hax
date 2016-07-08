using System.Collections.Generic;

namespace Hax.Connectors
{
    public abstract class ValueConnector : ConnectorBase
    {
        protected ValueConnector(INode source, INode destination) 
            : base(source, destination)
        {
        }

        public new IVariable Source => base.Source as IVariable;

        public new IVariable Destination => base.Destination as IVariable;

        public override IEnumerable<IDeviceCommunication> GetDeviceCommunications()
        {
            return Destination.GetDeviceCommunications();
        }
    }
}