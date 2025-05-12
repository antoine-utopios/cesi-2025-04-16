using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Cesi.Singleton.Classes
{
    public class DatabaseConnection
    {
        private static DatabaseConnection _instance;
        public static DatabaseConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DatabaseConnection();
                }

                return _instance;
            }
        }
        public DatabaseConnection()
        {
            
        }
        public void SaveToDatabase(object data)
        {
            // Sauvegarde de l'élément en base de données...
        }
    }
}
