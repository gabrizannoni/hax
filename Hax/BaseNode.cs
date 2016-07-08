using System;
using System.Collections.Generic;

namespace Hax
{
    public abstract class BaseNode : INode
    {
        private readonly List<IConnector> _in = new List<IConnector>();
        private readonly List<IConnector> _out = new List<IConnector>();

        protected BaseNode(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public IReadOnlyCollection<IConnector> In => _in;

        public IReadOnlyCollection<IConnector> Out => _out;

        public void AddConnector(IConnector connector)
        {
            if (connector == null)
                throw new ArgumentNullException(nameof(connector));

            if (connector.Source == this)
            {
                _out.Add(connector);
            }
            else if (connector.Destination == this)
            {
                _in.Add(connector);
            }
            else
            {
                throw new ArgumentException("This node is not source nor destination for connector", nameof(connector));
            }
        }

        public void RemoveConnector(IConnector connector)
        {
            if (connector == null)
                throw new ArgumentNullException(nameof(connector));

            if (connector.Source == this)
            {
                _out.Remove(connector);
            }
            else if (connector.Destination == this)
            {
                _in.Remove(connector);
            }
            else
            {
                throw new ArgumentException("This node is not source nor destination for connector", nameof(connector));
            }

        }
    }
}