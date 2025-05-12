using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocp.Exercice05.Classes
{
    public class AnalysisReport
    {
        public List<string> Results { get; } = new List<string>();

        public void AddResult(string result) => Results.Add(result);
    }

}
