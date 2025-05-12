namespace Lsp.Exercice05.Classes
{
    public class ExcelReport : Report
    {
        public override void Export(string path)
        {
            Console.WriteLine($"Exporting Excel to {path}");
        }

        public override string Preview()
        {
            throw new NotSupportedException("Excel preview not supported.");
        }
    }

}
