namespace Lsp.Exercice05.Classes
{
    public class PdfReport : Report
    {
        public override void Export(string path)
        {
            Console.WriteLine($"Exporting PDF to {path}");
        }

        public override string Preview()
        {
            return "PDF preview";
        }
    }

}
