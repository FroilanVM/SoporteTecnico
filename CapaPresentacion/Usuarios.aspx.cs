using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using SoporteTecnico.CapaLogica;

namespace SoporteTecnico
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Crear el objeto de conexión
                    ConexionBasedeDatos objConexion = new ConexionBasedeDatos();

                    // Obtener y abrir la conexión
                    using (SqlConnection conexion = objConexion.ObtenerConexion())
                    {
                        conexion.Open();
                    }

                }
                catch (Exception ex)
                {
                    // Mostrar el error si no logra conectarse
                    lMensaje.Text = "Error de conexión: " + ex.Message;
                }
            }
        }
        // Metodo para guardar un nuevo usuario
        protected void bGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos ingresados en los campos de texto
                int usuarioID = int.Parse(tUsuarioID.Text);
                string nombre = tNombre.Text;
                string correoElectronico = tCorreo.Text;
                string telefono = tTelefono.Text;

                // Enviar los datos a la capa logica para guardar el usuario
                int resultado = Usuarios_Logica.AgregarUsuario(
                    usuarioID, nombre, correoElectronico, telefono);

                // Mostrar el resultado de la operacion
                if (resultado > 0)
                {
                    lMensaje.Text = "Usuario agregado correctamente.";
                }
                else
                {
                    lMensaje.Text = "No se pudo agregar el usuario.";
                }
            }
            catch (Exception ex)
            {
                // Mostrar el error si ocurre algun problema
                lMensaje.Text = "Error: " + ex.Message;
            }
        }
        // Metodo para modificar un usuario existente
        protected void bModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos ingresados en los campos de texto
                int usuarioID = int.Parse(tUsuarioID.Text);
                string nombre = tNombre.Text;
                string correoElectronico = tCorreo.Text;
                string telefono = tTelefono.Text;

                // Enviar los datos a la capa logica para modificar el usuario
                int resultado = Usuarios_Logica.ModificarUsuario(
                    usuarioID, nombre, correoElectronico, telefono);

                // Mostrar el resultado de la operacion
                if (resultado > 0)
                {
                    lMensaje.Text = "Usuario modificado correctamente.";
                }
                else
                {
                    lMensaje.Text = "No se pudo modificar el usuario.";
                }
            }
            catch (Exception ex)
            {
                // Mostrar el error si ocurre algun problema
                lMensaje.Text = "Error: " + ex.Message;
            }
        }
        // Metodo para eliminar un usuario
        protected void bEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la identificacion del usuario
                int usuarioID = int.Parse(tUsuarioID.Text);

                // Enviar la identificacion a la capa logica para eliminar el usuario
                int resultado = Usuarios_Logica.EliminarUsuario(usuarioID);

                // Mostrar el resultado de la operacion
                if (resultado > 0)
                {
                    lMensaje.Text = "Usuario eliminado correctamente.";
                }
                else
                {
                    lMensaje.Text = "No se pudo eliminar el usuario.";
                }
            }
            catch (Exception ex)
            {
                // Mostrar el error si ocurre algun problema
                lMensaje.Text = "Error: " + ex.Message;
            }
        }
        // Metodo para consultar un usuario
        protected void bConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la identificacion del usuario
                int usuarioID = int.Parse(tUsuarioID.Text);

                // Consultar el usuario en la base de datos
                using (SqlDataReader lector = Usuarios_Logica.ConsultarUsuario(usuarioID))
                {
                    // Verificar si se encontro el usuario
                    if (lector.Read())
                    {
                        // Mostrar los datos encontrados en los campos de texto
                        tNombre.Text = lector["Nombre"].ToString();
                        tCorreo.Text = lector["CorreoElectronico"].ToString();
                        tTelefono.Text = lector["Telefono"].ToString();

                        lMensaje.Text = "Usuario encontrado correctamente.";
                    }
                    else
                    {
                        lMensaje.Text = "No se encontro el usuario.";
                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar el error si ocurre algun problema
                lMensaje.Text = "Error: " + ex.Message;
            }
        }
    }
}