using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBaseExample.Models;
using System.Threading.Tasks;

namespace Pagina_Web.Controllers
{
    public class HomeController : Controller
    {

        Model_User user = new Model_User();

        public ActionResult Index()
        {
            return View();
        }

//Registro de Usuarios ----------------------------------------------------
        public ActionResult Registro()
        {
            ViewBag.Message = "Registro de Usuario";
            return View();
        }
      //-------------------------------------------------------
        [HttpPost]
        public ActionResult Registro(Model_User datos)
        {
            user.nombres = Request.Form["nombres"].ToString();
            user.apellidos = Request.Form["apellidos"].ToString();
            user.correo = Request.Form["correo"].ToString();
            user.contrasena = Request.Form["contrasena"].ToString();

            user.RegistrarUsuario(datos.nombres, datos.apellidos, datos.correo, datos.contrasena);

            return View("Index");
        }

//Inicio de Sesion Usuarios ------------------------------------------------

       // [AllowAnonymous]
        public ActionResult Iniciar()
        {
            if (Session["start"] != null)
            {
                return View("Index");
            }
            else
            {
                ViewBag.Message = "Inicar Sesion";
                return View();
            }
            
        }
       //-------------------------------------------------------
        [HttpPost]
        public ActionResult Iniciar(Model_User datos)
        {
            user.correo = Request.Form["correo"].ToString();
            user.contrasena = Request.Form["contrasena"].ToString();
            if (user.BuscarUsuario(datos.correo, datos.contrasena))
            {
                Session["start"] = 0;
                return View("Index");
            }
            else
            {
                ViewBag.Message = "Datos Incorrectos";
                return View();
            }
        }
//Administracion de menu

        public ActionResult RegistroMenu()
        {
            user.DatosMenu();
            return View();
        }


        [HttpPost]
        public ActionResult RegistroMenu(Model_User datos)
        {

            user.nombreMenu = Request.Form["NombreMenu"].ToString();
            user.link = Request.Form["Link"].ToString();
            user.IdUsuario = Pagina_Web.Models.TipoUsuario.IdTipoUsuario[1]+"";
            user.RegistrarMenu(datos.nombreMenu, datos.link, "1");

            return View("RegistroMenu");
        }
//Administracion de SubMenu

        public ActionResult RegistroSubMenu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistroSubMenu(Model_User datos)
        {
            return View("Index");
        }

/// <summary>
/// ///

        public ActionResult Cerrar()
        {
            Session["start"] = null;
            Pagina_Web.Models.Menu.limpiarMenu();
            Pagina_Web.Models.Persona.limpiar();
            Response.Redirect("Iniciar");
            return View("Iniciar");

        }

        //Registrar Libro
        public ActionResult RegistrarLibro()
        {
            if (Session["start"] == null)
            {
                Response.Redirect("Iniciar");   
            }
            return View();
        }
        
    }
}