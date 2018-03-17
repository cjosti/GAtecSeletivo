using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GAtec.Seletivo.Util.Settings
{
    public static class SeletivoSettings
    {
        public static string applicationName
        {
            get
            {
                return ConfigurationManager.AppSettings["ApplicationName"];
            }
        }

        public static string connectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Seletivo"].ConnectionString;
            }
        }

    }
}
