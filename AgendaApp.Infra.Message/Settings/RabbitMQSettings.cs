using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Messages.Settings
{
    public class RabbitMQSettings
    {
        public readonly static string Hostname = "localhost";
        public readonly static int Port = 5672;
        public readonly static string Username = "guest";
        public readonly static string Password = "guest";
        public readonly static string Queue = "notificacoes-pessoa";
    }
}
