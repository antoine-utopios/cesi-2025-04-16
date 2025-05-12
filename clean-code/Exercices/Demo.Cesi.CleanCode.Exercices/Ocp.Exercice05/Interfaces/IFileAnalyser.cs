using Ocp.Exercice05.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocp.Exercice05.Interfaces
{
    public interface IFileAnalyzer
    {
        void Analyze(string filePath, AnalysisReport report);
    }

}
