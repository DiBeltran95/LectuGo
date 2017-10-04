using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina_Web.Models
{
    public class Persona
    {
        public static String nombres = "";
        public static String Apellidos = "";
        public static String Correo = "";
        public static String idTipo = "";
        public static void limpiar()
        {
            nombres = "";
            Apellidos = "";
            Correo = "";
            idTipo = "";
        }
    }
}