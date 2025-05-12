using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocp.Exercice03.Classes
{
    public class NotificationService
    {
        public void NotifyAllItems(List<Tuple<string, string>> items)
        {
            foreach (var item in items)
            {
                if (item.Item1 == "Email")
                {
                    Console.WriteLine("[Email] Notification: " + item.Item2);
                } else if (item.Item1 == "SMS")
                {
                    Console.WriteLine("[SMS] Notification: " + item.Item2);
                }
                else
                {
                    Console.WriteLine("[Unknown] Notification: " + item.Item2);
                }
            }
        }
    }
}
