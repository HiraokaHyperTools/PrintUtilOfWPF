# PrintUtilOfWPF
Preview/Save XPS from your WPF Visual object

[nuget](https://www.nuget.org/packages/PrintUtilOfWPF/)

Sample.cs:
```cs
using PrintUtilOfWPF;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

void testPrint() {
    var pages = new List<DocumentPage>();

    var a4Size = new Size(793, 1122);
    var a4Rect = new Rect(a4Size);

    // prepare your Page object.
    Page page = new Page();

    page.Content = new Label {
        Content = "test page",
        FontSize = 60,
        HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
        VerticalAlignment = System.Windows.VerticalAlignment.Center,
    };

    // These are required ones.
    page.Measure(a4Size);
    page.Arrange(a4Rect);
    page.UpdateLayout();

    pages.Add(new DocumentPage(page, a4Size, a4Rect, a4Rect));

    var printPages = new PrintPages(pages) {
        PageSize = a4Size,
        JobTitle = "testPage"
    };

    PrintUtil.Preview(printPages.JobTitle, printPages);
}
```
