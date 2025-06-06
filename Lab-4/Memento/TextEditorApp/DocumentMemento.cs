﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento.TextEditorApp
{
    public class DocumentMemento
    {
        private readonly TextDocument _documentState;
        private readonly DateTime _snapshotTime;

        public DocumentMemento(TextDocument document)
        {
            _documentState = document.Clone();
            _snapshotTime = DateTime.Now;
        }

        internal TextDocument GetState()
        {
            return _documentState.Clone();
        }

        internal DateTime GetSnapshotTime()
        {
            return _snapshotTime;
        }
    }
}
