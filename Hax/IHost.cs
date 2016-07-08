using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hax
{
    public interface IHost
    {
        void AddRoot(INode node);

        INode FindNode(string path);

        IReadOnlyCollection<INode> Roots { get; }
    }

    public static class HostExtensions
    {
        public static T FindNode<T>(this IHost host, string path) where T : INode
        {
            return (T) host.FindNode(path);
        }
    }

    public class Host : IHost
    {
        private readonly List<INode> _roots = new List<INode>();

        public void AddRoot(INode node)
        {
            if (_roots.Contains(node))
                return;

            if (_roots.Any(n => n.Name == node.Name))
                throw new ArgumentException("Root node names must be unique");

            _roots.Add(node);
        }

        public INode FindNode(string path)
        {
            path = path.Trim('/');
            string[] pathParts = path.Split('/');
            return FindNode(pathParts, 0, _roots);
        }

        public IReadOnlyCollection<INode> Roots => _roots;

        private INode FindNode(string[] pathParts, int partIndex, IEnumerable<INode> nodes)
        {
            var name = pathParts[partIndex];
            INode node = nodes.FirstOrDefault(n => n.Name == name);

            if (node == null)
                return null;

            var newIndex = partIndex + 1;
            if (pathParts.Length == newIndex)
                return node;

            return FindNode(pathParts, newIndex, node.Out.Select(c => c.Destination));
        }
    }
}
