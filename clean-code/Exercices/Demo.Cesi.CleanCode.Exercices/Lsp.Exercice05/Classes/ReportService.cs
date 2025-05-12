namespace Lsp.Exercice05.Classes
{
    public class ReportService
    {
        public void GeneratePreview(Report report)
        {
            Console.WriteLine(report.Preview());
        }
    }

}
