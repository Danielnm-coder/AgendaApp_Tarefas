using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Security.Settings
{
    public class JwtTokenSettings
    {
        public static string SecretKey = "83A84B3A-CEBA-4B2B-990F-DE8B5B5FCC59";

        public static int ExpirationInHours = 1;
    }
}



