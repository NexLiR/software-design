using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.TextEditorApp
{
    public class TextEditor
    {
        private TextDocument _currentDocument;
        private readonly DocumentHistory _history;

        public TextEditor()
        {
            _currentDocument = new TextDocument();
            _history = new DocumentHistory();
            _history.SaveState(_currentDocument);
        }

        public void SetContent(string content)
        {
            _currentDocument.Content = content;
        }

        public void SetFontName(string fontName)
        {
            _currentDocument.FontName = fontName;
        }

        public void SetFontSize(int fontSize)
        {
            _currentDocument.FontSize = fontSize;
        }

        public void ToggleBold()
        {
            _currentDocument.IsBold = !_currentDocument.IsBold;
        }

        public void SaveState()
        {
            _history.SaveState(_currentDocument);
            Console.WriteLine("Document state saved.");
        }

        public void Undo()
        {
            if (_history.CanUndo())
            {
                _currentDocument = _history.Undo(_currentDocument);
                Console.WriteLine("Undo completed.");
            }
            else
            {
                Console.WriteLine("No more history available.");
            }
        }

        public void Redo()
        {
            TextDocument redoState = _history.Redo();
            if (redoState != null)
            {
                _currentDocument = redoState;
                Console.WriteLine("Redo operation completed.");
            }
            else
            {
                Console.WriteLine("No more history available.");
            }
        }

        public void DisplayDocument()
        {
            Console.WriteLine("\n=== Current Document State ===");
            Console.WriteLine(_currentDocument.ToString());
        }

        public void DisplayHistory()
        {
            _history.DisplayHistory();
        }
    }
}
