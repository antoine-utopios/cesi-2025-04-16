namespace Lsp.Exercice05.Classes
{
    public class HtmlReport : Report
    {
        public override void Export(string path)
        {
            Console.WriteLine($"Exporting HTML to {path}");
        }

        public override string Preview()
        {
            return "<html><body>Preview</body></html>";
        }
    }

}
