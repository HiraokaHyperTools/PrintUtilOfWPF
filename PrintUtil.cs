using System;
using System.IO;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;

namespace PrintUtilOfWPF {
    public class PrintUtil {
        public static void Preview(
            String jobTitle,
            DocumentPaginator paginator
        ) {
            var window = new PrintPreviewWindow();
            window.JobTitle = jobTitle;
            window.DoPreview(paginator);
        }

        public static void Save(
            String outputXpsFilePath,
            DocumentPaginator paginator
        ) {
            if (File.Exists(outputXpsFilePath)) {
                File.Delete(outputXpsFilePath);
            }
            using (var document = new XpsDocument(outputXpsFilePath, FileAccess.ReadWrite)) {
                var writer = XpsDocument.CreateXpsDocumentWriter(document);
                writer.Write(paginator);
            }
        }
    }
}
