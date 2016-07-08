namespace Hax.Connectors
{
    public abstract class RelationConnector : ConnectorBase
    {
        protected RelationConnector(INode source, INode destination) 
            : base(source, destination)
        {
        }
    }
}