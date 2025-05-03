using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Iterator
{
    public class LightDepthFirstIterator : ILightIterator
    {
        private LightElementNode _root;
        private Stack<LightNode> _stack;
        private LightNode _current;
        private bool _includeRoot;

        public LightDepthFirstIterator(LightElementNode root, bool includeRoot = true)
        {
            _root = root;
            _includeRoot = includeRoot;
            Reset();
        }

        public bool HasNext()
        {
            return _stack.Count > 0;
        }

        public LightNode Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("No more elements to iterate");
            }

            _current = _stack.Pop();

            if (_current is LightElementNode elementNode)
            {
                for (int i = elementNode._children.Count - 1; i >= 0; i--)
                {
                    _stack.Push(elementNode._children[i]);
                }
            }

            return _current;
        }

        public void Reset()
        {
            _stack = new Stack<LightNode>();
            _current = null;

            if (_includeRoot)
            {
                _stack.Push(_root);
            }
            else
            {
                for (int i = _root._children.Count - 1; i >= 0; i--)
                {
                    _stack.Push(_root._children[i]);
                }
            }
        }
    }
}
