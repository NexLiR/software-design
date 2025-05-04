using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern.Command.Commands
{
    public class AddCssClassCommand : ICommand
    {
        private readonly LightElementNode _element;
        private readonly string _cssClass;

        public AddCssClassCommand(LightElementNode element, string cssClass)
        {
            _element = element;
            _cssClass = cssClass;
        }

        public string Description => $"Add CSS class '{_cssClass}' to {_element.TagName}";

        public void Execute()
        {
            _element.AddCssClass(_cssClass);
        }

        public void Undo()
        {
            List<string> currentClasses = new List<string>();

            string classesString = _element.GetCssClassesString();
            if (!string.IsNullOrEmpty(classesString))
            {
                currentClasses = classesString.Split(' ').ToList();
            }

            currentClasses.Remove(_cssClass);

            foreach (string cssClass in currentClasses)
            {
                if (!string.IsNullOrEmpty(cssClass))
                {
                    _element.AddCssClass(cssClass);
                }
            }
        }
    }
}
