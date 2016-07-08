using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hax.Connectors
{
    public class ContainsConnector : RelationConnector
    {
        public static ContainsConnector Connect(INode source, INode destination)
        {
            var c = new ContainsConnector(source, destination);    
            AddConnectorToSourceAndDestination(c);
            return c;
        }

        protected ContainsConnector(INode source, INode destination) 
            : base(source, destination)
        {
        }
    }
}
