using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Template
{
    public abstract class LightNodeWithHooks : LightNode
    {
        public sealed override string GetOuterHTML()
        {
            OnBeforeRender();
            string html = GenerateHTML();
            OnAfterRender();
            return html;
        }

        protected abstract string GenerateHTML();

        protected virtual void OnBeforeRender() { }
        protected virtual void OnAfterRender() { }
        protected virtual void OnCreated() { }
        protected virtual void OnRemoved() { }
        protected virtual void OnInserted() { }
        protected virtual void OnStylesApplied() { }
        protected virtual void OnClassListApplied() { }

        public void NotifyInserted()
        {
            OnInserted();
        }
        public void NotifyRemoved()
        {
            OnRemoved();
        }
        public void NotifyStylesApplied()
        {
            OnStylesApplied();
        }
        public void NotifyClassListApplied()
        {
            OnClassListApplied();
        }
    }
}
