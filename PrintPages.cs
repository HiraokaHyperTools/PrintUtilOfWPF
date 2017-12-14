using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace PrintUtilOfWPF {
    public class PrintPages : DocumentPaginator, IDocumentPaginatorSource {
        private readonly List<DocumentPage> _Pages = new List<DocumentPage>();
        private readonly Action<int> _OnGetPage;
        Size _PageSize;
        String _JobTitle;

        public PrintPages(List<DocumentPage> Pages) {
            this._Pages = Pages;
        }

        public PrintPages(List<DocumentPage> Pages, Action<int> OnGetPage) {
            this._Pages = Pages;
            this._OnGetPage = OnGetPage;
        }

        public override DocumentPage GetPage(int pageNumber) {
            _OnGetPage?.Invoke(pageNumber);
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
