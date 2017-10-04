using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina_Web.Models
{
    public class Menu
    {
        public static List<String> nombre = new List<string>();
        public static List<String> enlace = new List<string>();

        public static List<String> sudNombre = new List<string>();
        public static List<String> sudEnlace = new List<string>();
        static public void limpiarMenu()
        {
            sudEnlace = new List<string>(); 
            sudNombre = new List<string>(); 
            enlace = new List<string>(); 
            nombre = new List<string>();
        }

    }
}