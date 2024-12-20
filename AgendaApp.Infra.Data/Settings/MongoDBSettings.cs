using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Settings
{
    public class MongoDBSettings
    {
        /// <summary>
        /// Endereço para conexão com o servidor do MongoDB
        /// </summary>
        public static string Host => "mongodb+srv://usuariocoti:coti@cluster0.ezddb.mongodb.net/";

        /// <summary>
        /// Nome do banco de dados do MongoDB
        /// </summary>
        public static string Database => "BDAgenda";
    }
}
