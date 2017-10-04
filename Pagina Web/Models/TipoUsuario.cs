using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina_Web.Models
{
    public class TipoUsuario
    {

        public static List<int> IdTipoUsuario = new List<int>();
        public static List<String> NombreTipoUsuario = new List<string>();
        public static List<int> IdMenu = new List<int>();
        public static List<String> NombreMenu = new List<string>();
        public static List<String> Link = new List<string>();
        public static List<int> TipoUsaurio = new List<int>();

        static public void limpiarTipoUsuario()
        {
            IdTipoUsuario = new List<int>();
            NombreTipoUsuario = new List<string>();
        }

        static public void limpiarMenu()
        {
            IdMenu = new List<int>();
            NombreMenu = new List<string>();
            Link = new List<string>();
            TipoUsaurio = new List<int>();
        }
    }
}