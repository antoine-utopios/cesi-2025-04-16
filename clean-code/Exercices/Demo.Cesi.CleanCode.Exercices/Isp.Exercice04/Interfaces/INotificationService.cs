using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isp.Exercice04.Interfaces
{
    public interface INotificationService
    {
        void SendEmail(string to, string subject, string body);
        void SendSms(string phoneNumber, string message);
        void SendPush(string deviceToken, string message);
    }

}
