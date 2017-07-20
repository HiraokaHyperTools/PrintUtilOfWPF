using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace PrintUtilOfWPF {
    public class PrintPages : DocumentPaginator, IDocumentPaginatorSource {
        List<DocumentPage> _Pages = new List<DocumentPage>();
        Size _PageSize;
        String _JobTitle;

        public PrintPages(List<DocumentPage> Pages) {
            this._Pages = Pages;
            this._JobTitle = JobTitle;
        }

        public override DocumentPage GetPage(int pageNumber) {
            return _Pages[pageNumber];
        }

        public override bool IsPageCountValid {
            get { return true; }
        }

        public override int PageCount {
            get { return _Pages.Count; }
        }

        public override Size PageSize {
            get { return _PageSize; }
            set { _PageSize = value; }
        }

        public override IDocumentPaginatorSource Source {
            get { return this; }
        }

        DocumentPaginator IDocumentPaginatorSource.DocumentPaginator {
            get { return this; }
        }

        public string JobTitle {
            get {
                return _JobTitle;
            }
            set {
                _JobTitle = value;
            }
        }
    }
}
