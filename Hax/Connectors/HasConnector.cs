using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hax.Connectors
{
    public class HasConnector : RelationConnector
    {
        public static HasConnector Connect(INode source, IVariable destination)
        {
            var c = new HasConnector(source, destination);
            AddConnectorToSourceAndDestination(c);
            return c;
        }

        protected HasConnector(INode source, INode destination) 
            : base(source, destination)
        {
        }
    }
}
