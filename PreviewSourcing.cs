using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;

namespace PrintUtilOfWPF
{
    public class PreviewSourcing : IDisposable
    {
        private readonly XpsDocument _document;
        private readonly string _fileName;

        public FixedDocumentSequence DocumentSequence { get; }

        public PreviewSourcing(DocumentPaginator visual)
        {
            _fileName = System.IO.Path.GetRandomFileName();
            // write the XPS document
            using (var document = new XpsDocument(_fileName, FileAccess.ReadWrite))
            {
                var writer = XpsDocument.CreateXpsDocumentWriter(document);
                writer.Write(visual);
            }

            {
                _document = new XpsDocument(_fileName, FileAccess.Read);
                var documentSequence = _document.GetFixedDocumentSequence();

                DocumentSequence = documentSequence;
            }
        }

        public void Dispose()
        {
            _document?.Close();

            if (File.Exists(_fileName))
            {
                try
                {
                    File.Delete(_fileName);
                }
                catch
                {
                    // ignore
                }
            }
        }
    }
}
