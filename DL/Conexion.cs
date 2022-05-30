using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DL
{
    class Conexion
    {
        public static string GetConnectionString()
        {

            return System.Configuration.ConfigurationManager.ConnectionStrings["Examen4"].ConnectionString.ToString();
        }
    }
}
