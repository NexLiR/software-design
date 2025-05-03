using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Iterator
{
    public class LightBreadthFirstIterator : ILightIterator
    {
        private LightElementNode _root;
        private Queue<LightNode> _queue;
        private LightNode _current;
        private bool _includeRoot;

        public LightBreadthFirstIterator(LightElementNode root, bool includeRoot = true)
        {
            _root = root;
            _includeRoot = includeRoot;
            Reset();
        }

        public bool HasNext()
        {
            return _queue.Count > 0;
        }

        public LightNode Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("No more elements to iterate");
            }

            _current = _queue.Dequeue();

            if (_current is LightElementNode elementNode)
            {
                foreach (var child in elementNode._children)
                {
                    _queue.Enqueue(child);
                }
            }

            return _current;
        }

        public void Reset()
        {
            _queue = new Queue<LightNode>();
            _current = null;

            if (_includeRoot)
            {
                _queue.Enqueue(_root);
            }
            else
            {
                foreach (var child in _root._children)
                {
                    _queue.Enqueue(child);
                }
            }
        }
    }
}
