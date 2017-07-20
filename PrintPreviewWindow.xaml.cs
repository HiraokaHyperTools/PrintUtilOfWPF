using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Xps.Packaging;

namespace PrintUtilOfWPF {
    /// <summary>
    /// PrintPreviewWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class PrintPreviewWindow : Window {
        public PrintPreviewWindow() {
            InitializeComponent();
        }

        // http://stackoverflow.com/questions/588662/how-do-i-set-the-name-of-the-print-job-when-using-documentviewer-control

        public string JobTitle {
            get {
                return Title;
            }
            set {
                Title = value;
            }
        }

        private void Print_PreviewExecuted(object sender, ExecutedRoutedEventArgs e) {
            var printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true) {
                printDialog.PrintDocument(documentViewer.Document.DocumentPaginator, JobTitle);
            }
        }

        private void Print_Executed(object sender, ExecutedRoutedEventArgs e) {
            //needed so that preview executed works
        }

        public void DoPreview(DocumentPaginator visual) {
            var fileName = System.IO.Path.GetRandomFileName();
            try {
                // write the XPS document
                using (var document = new XpsDocument(fileName, FileAccess.ReadWrite)) {
                    var writer = XpsDocument.CreateXpsDocumentWriter(document);
                    writer.Write(visual);
                }

                // Read the XPS document into a dynamically generated
                // preview Window 
                using (var document = new XpsDocument(fileName, FileAccess.Read)) {
                    var documentSequence = document.GetFixedDocumentSequence();

                    documentViewer.Document = documentSequence as IDocumentPaginatorSource;

                    ShowDialog();
                }
            }
            finally {
                if (File.Exists(fileName)) {
                    try {
                        File.Delete(fileName);
                    }
                    catch {

                    }
                }
            }
        }
    }
}
