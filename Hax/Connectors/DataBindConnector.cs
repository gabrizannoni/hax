using System;

namespace Hax.Connectors
{
    public class DataBindConnector : ValueConnector
    {
        public static DataBindConnector Connect(IVariable source, IVariable destination)
        {
            var c = new DataBindConnector(source, destination);
            AddConnectorToSourceAndDestination(c);
            return c;
        }

        protected DataBindConnector(IVariable source, IVariable destination) 
            : base(source, destination)
        {
            source.ValueChanged += (sender, args) => destination.SetValue(source.GetValue());
        }
    }
}
