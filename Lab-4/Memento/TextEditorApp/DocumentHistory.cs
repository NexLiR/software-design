using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.TextEditorApp
{
    public class DocumentHistory
    {
        private readonly List<DocumentMemento> _history = new List<DocumentMemento>();
        private int _currentIndex = -1;

        public void SaveState(TextDocument document)
        {
            if (_currentIndex < _history.Count - 1)
            {
                _history.RemoveRange(_currentIndex + 1, _history.Count - _currentIndex - 1);
            }

            _history.Add(new DocumentMemento(document));
            _currentIndex = _history.Count - 1;
        }

        public TextDocument Undo(TextDocument currentDocument)
        {
            if (_currentIndex == _history.Count - 1 && _history.Count > 0)
            {
                TextDocument lastState = _history[_currentIndex].GetState();
                if (!AreDocumentsEqual(lastState, currentDocument))
                {
                    SaveState(currentDocument);
                    _currentIndex--;
                }
            }

            if (_currentIndex > 0)
            {
                _currentIndex--;
                return _history[_currentIndex].GetState();
            }
            else if (_currentIndex == 0)
            {
                return _history[0].GetState();
            }

            return currentDocument;
        }

        public TextDocument Redo()
        {
            if (_currentIndex < _history.Count - 1)
            {
                _currentIndex++;
                return _history[_currentIndex].GetState();
            }

            return null;
        }

        public bool CanUndo()
        {
            return _currentIndex >= 0;
        }

        public bool CanRedo()
        {
            return _currentIndex < _history.Count - 1;
        }

        public void DisplayHistory()
        {
            Console.WriteLine("\n--- Document History ---");
            for (int i = 0; i < _history.Count; i++)
            {
                DocumentMemento memento = _history[i];
                string marker = (i == _currentIndex) ? " (current)" : "";
                Console.WriteLine($"{i + 1}. {memento.GetSnapshotTime():HH:mm:ss}{marker}");
            }
            Console.WriteLine("----------------------");
        }

        private bool AreDocumentsEqual(TextDocument doc1, TextDocument doc2)
        {
            return doc1.Content == doc2.Content &&
                   doc1.FontName == doc2.FontName &&
                   doc1.FontSize == doc2.FontSize &&
                   doc1.IsBold == doc2.IsBold;
        }
    }
}
