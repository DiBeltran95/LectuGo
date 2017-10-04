using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Conexion;
using MySql.Data.MySqlClient;
using System.Data;
using Pagina_Web.Models;
namespace DataBaseExample.Models
{
    public class Model_User
    {

        public string nombres { get; set; }

        public string apellidos { get; set; }

        public string correo { get; set; }

        public string contrasena { get; set; }

        public string nombreMenu { get; set; }

        public string IdUsuario { get; set; }

        public string link { get; set; }

        private Conex conn = new Conex();
        private MySqlCommand Comman = new MySqlCommand();

        public bool RegistrarUsuario(string nombres, string apellidos, string correo, string contrasena)
        {
            try
            {
                Comman.CommandText = "INSERT INTO usuario (Nombres, Apellidos, Correo, Contrasena, idTipoUsuario) VALUES('" + nombres + "','" + apellidos + "','" + correo + "', PASSWORD('" + contrasena + "'), '2')";
                 Comman.Connection = conn.ConexionMySql();
                Comman.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool BuscarUsuario(string correo, string contrasena)
        {
            Comman.CommandText = "SELECT idusuario, Nombres, Apellidos, Correo,  idTipoUsuario FROM usuario WHERE(Correo='" + correo + "' AND Contrasena= PASSWORD('" + contrasena + "'))";
            Comman.Connection = conn.ConexionMySql();
            MySqlDataReader consulta = Comman.ExecuteReader();
            List<String> Datos = new List<string>();
            int idUsuario = 0;
            if (consulta.HasRows)
            {
                while (consulta.Read())
                {
                    idUsuario = Convert.ToInt16(consulta[0]);
                    Persona.nombres = (consulta[1] + "");

                    Persona.Apellidos = (consulta[2] + "");

                    Persona.Correo = (consulta[3] + "");

                    Persona.idTipo = (consulta[4] + "");
                }
                consulta.Close();

                Comman.CommandText = "SELECT  m.Nombre , m.Link,  sm.Nombre , sm.Link FROM usuario u " +
                    "inner join tipousuario tu on u.idtipousuario=tu.idtipousuario " +
                    "right join menu m on m.tipousuario_idtipousuario=tu.idtipousuario " +
                    "left join submenu_has_menu shm on shm.Menu_idMenu=m.idmenu " +
                    "left join submenu sm on sm.idsubmenu=shm.SubMenu_idSubMenu WHERE u.idusuario=" + idUsuario + "";
                Comman.Connection = conn.ConexionMySql();
                MySqlDataReader consulta2 = Comman.ExecuteReader();
                Menu.limpiarMenu();
                while (consulta2.Read())
                {
                    Menu.nombre.Add(consulta2[0] + "");

                    Menu.enlace.Add(consulta2[1] + "");

                    Menu.sudNombre.Add(consulta2[2] + "");

                    Menu.sudEnlace.Add(consulta2[3] + "");
                }
                consulta2.Close();
                return true;
            }
            else
            {
                return false;
            }

        }

        internal void ConsultaMenu(object v)
        {
            throw new NotImplementedException();
        }

        public bool DatosMenu()
        {
            Comman.CommandText = "SELECT idTipoUsuario, Nombre FROM lectgo.tipousuario";
            Comman.Connection = conn.ConexionMySql();
            MySqlDataReader consulta = Comman.ExecuteReader();
            TipoUsuario.limpiarTipoUsuario();
            TipoUsuario.limpiarMenu();
            while (consulta.Read())
            {
                TipoUsuario.IdTipoUsuario.Add(Convert.ToInt32(consulta[0]));
                TipoUsuario.NombreTipoUsuario.Add(consulta[1] + "");
            }
            consulta.Close();

            Comman.CommandText = "SELECT * FROM lectgo.menu order by TipoUsuario_idTipoUsuario asc";
            Comman.Connection = conn.ConexionMySql();
            MySqlDataReader consulta2 = Comman.ExecuteReader();
            while (consulta2.Read())
            {
                TipoUsuario.IdMenu.Add(Convert.ToInt32(consulta2[0]));
                TipoUsuario.NombreMenu.Add(consulta2[1] + "");
                TipoUsuario.Link.Add(consulta2[2] + "");
                TipoUsuario.TipoUsaurio.Add(Convert.ToInt32(consulta2[3]));

            }
            consulta2.Close();

            return true;
        }

        public bool ConsultaMenu(int IdTipoUsaurio)
        {
            TipoUsuario.limpiarMenu();
            Comman.CommandText = "SELECT * FROM lectgo.menu order by TipoUsuario_idTipoUsuario asc";
            Comman.Connection = conn.ConexionMySql();
            MySqlDataReader consulta2 = Comman.ExecuteReader();
            while (consulta2.Read())
            {
                TipoUsuario.IdMenu.Add(Convert.ToInt32(consulta2[0]));
                TipoUsuario.NombreMenu.Add(consulta2[1] + "");
                TipoUsuario.Link.Add(consulta2[2] + "");
            }
            consulta2.Close();

            return true;
        }

        public bool RegistrarMenu(string NombreMenu, string link, string idTipoUsuario)
        {
            try
            {
                Comman.CommandText = "INSERT INTO lectgo.menu (Nombre, Link, TipoUsuario_idTipoUsuario) VALUES('" + NombreMenu + "','" + link + "','" + idTipoUsuario + "')";
                 Comman.Connection = conn.ConexionMySql();
                Comman.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}