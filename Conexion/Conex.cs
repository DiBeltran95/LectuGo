using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Conexion
{
    public class Conex
    {
        //private static string stringConnection = ConfigurationManager.ConnectionStrings["conexion_mysql"].ConnectionString;
        public MySqlConnection ConexionMySql()
        {
            MySqlConnection Connection = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexion_mysql"].ConnectionString);
            // MySqlConnection Connection = new MySqlConnection(stringConnection);
            try
            {
                Connection.Open();
            }
            catch (Exception e)
            {
                throw new Exception("No se puedo realizar la conexion " + e.Message);
            }
            return Connection;
        }

    }
}
