using Composite.CompositePattern.ImageLoadStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.CompositePattern
{
    public class LightImageNode : LightElementNode
    {
        private readonly ImageLoadContext _imageLoadContext;
        private string _source;
        private string _altText;
        private int _width;
        private int _height;

        public LightImageNode(string source, string altText = "", int width = 0, int height = 0)
            : base("img", DisplayType.Inline, ClosingType.SelfClosing)
        {
            _imageLoadContext = new ImageLoadContext();
            SetSource(source);
            _altText = altText;
            _width = width;
            _height = height;
        }

        public string Source => _source;
        public string AltText => _altText;
        public int Width => _width;
        public int Height => _height;

        public void SetSource(string source)
        {
            if (_imageLoadContext.CanLoadImage(source))
            {
                try
                {
                    _source = _imageLoadContext.LoadImage(source);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading image: {ex.Message}");
                    _source = string.Empty;
                }
            }
            else
            {
                Console.WriteLine($"Cannot handle image source: {source}");
                _source = string.Empty;
            }
        }

        public void SetAltText(string altText)
        {
            _altText = altText;
        }

        public void SetDimensions(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public override string GetOuterHTML()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<");
            sb.Append(TagName);

            if (!string.IsNullOrEmpty(_source))
            {
                sb.Append(" src=\"");
                sb.Append(_source);
                sb.Append("\"");
            }

            if (!string.IsNullOrEmpty(_altText))
            {
                sb.Append(" alt=\"");
                sb.Append(_altText);
                sb.Append("\"");
            }

            if (_width > 0)
            {
                sb.Append(" width=\"");
                sb.Append(_width);
                sb.Append("\"");
            }

            if (_height > 0)
            {
                sb.Append(" height=\"");
                sb.Append(_height);
                sb.Append("\"");
            }

            if (HasCssClasses())
            {
                sb.Append(" class=\"");
                sb.Append(GetCssClassesString());
                sb.Append("\"");
            }

            sb.Append(" />");
            return sb.ToString();
        }
    }
}
