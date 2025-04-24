using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.TextEditorApp
{
    public class TextDocument
    {
        public string Content { get; set; }
        public string FontName { get; set; }
        public int FontSize { get; set; }
        public bool IsBold { get; set; }

        public TextDocument()
        {
            Content = string.Empty;
            FontName = "Arial";
            FontSize = 12;
            IsBold = false;
        }

        public TextDocument(string content, string fontName, int fontSize, bool isBold)
        {
            Content = content;
            FontName = fontName;
            FontSize = fontSize;
            IsBold = isBold;
        }

        public TextDocument Clone()
        {
            return new TextDocument(Content, FontName, FontSize, IsBold);
        }

        public override string ToString()
        {
            string boldStatus = IsBold ? "Bold" : "Regular";
            return $"Content: \"{Content}\"\nFont: {FontName}, {FontSize}pt, {boldStatus}";
        }
    }
}
