using System;
using System.Data.SqlClient;
using System.Web.UI;
using SoporteTecnico.CapaLogica;

namespace SoporteTecnico.CapaPresentacion
{
    public partial class Equipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Crear el objeto de conexion
                    ConexionBasedeDatos objConexion = new ConexionBasedeDatos();

                    // Obtener y abrir la conexion
                    using (SqlConnection conexion = objConexion.ObtenerConexion())
                    {
                        conexion.Open();
                    }

                }
                catch (Exception ex)
                {
                    // Mostrar el error si no logra conectarse
                    lMensaje.Text = "Error de conexion: " + ex.Message;
                }
            }
        }

        // Metodo para guardar un nuevo equipo
        protected void bGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos ingresados en los campos de texto
                int equipoID = int.Parse(tEquipoID.Text);
                string tipoEquipo = tTipoEquipo.Text;
                string modelo = tModelo.Text;
                int usuarioID = int.Parse(tUsuarioID.Text);

                // Enviar los datos a la capa logica para guardar el equipo
                int resultado = Equipos_Logica.AgregarEquipo(
                    equipoID, tipoEquipo, modelo, usuarioID);

                // Mostrar el resultado de la operacion
                if (resultado > 0)
                {
                    lMensaje.Text = "Equipo agregado correctamente.";
                }
                else
                {
                    lMensaje.Text = "No se pudo agregar el equipo.";
                }
            }
            catch (Exception ex)
            {
                // Mostrar el error si ocurre algun problema
                lMensaje.Text = "Error: " + ex.Message;
            }
        }

        // Metodo para modificar un equipo existente
        protected void bModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los datos ingresados en los campos de texto
                int equipoID = int.Parse(tEquipoID.Text);
                string tipoEquipo = tTipoEquipo.Text;
                string modelo = tModelo.Text;
                int usuarioID = int.Parse(tUsuarioID.Text);

                // Enviar los datos a la capa logica para modificar el equipo
                int resultado = Equipos_Logica.ModificarEquipo(
                    equipoID, tipoEquipo, modelo, usuarioID);

                // Mostrar el resultado de la operacion
                if (resultado > 0)
                {
                    lMensaje.Text = "Equipo modificado correctamente.";
                }
                else
                {
                    lMensaje.Text = "No se pudo modificar el equipo.";
                }
            }
            catch (Exception ex)
            {
                // Mostrar el error si ocurre algun problema
                lMensaje.Text = "Error: " + ex.Message;
            }
        }

        // Metodo para eliminar un equipo
        protected void bEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la identificacion del equipo
                int equipoID = int.Parse(tEquipoID.Text);

                // Enviar la identificacion a la capa logica para eliminar el equipo
                int resultado = Equipos_Logica.EliminarEquipo(equipoID);

                // Mostrar el resultado de la operacion
                if (resultado > 0)
                {
                    lMensaje.Text = "Equipo eliminado correctamente.";
                }
                else
                {
                    lMensaje.Text = "No se pudo eliminar el equipo.";
                }
            }
            catch (Exception ex)
            {
                // Mostrar el error si ocurre algun problema
                lMensaje.Text = "Error: " + ex.Message;
            }
        }

        // Metodo para consultar un equipo
        protected void bConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la identificacion del equipo
                int equipoID = int.Parse(tEquipoID.Text);

                // Consultar el equipo en la base de datos
                using (SqlDataReader lector = Equipos_Logica.ConsultarEquipo(equipoID))
                {
                    // Verificar si se encontro el equipo
                    if (lector != null && lector.Read())
                    {
                        // Mostrar los datos encontrados en los campos de texto
                        tTipoEquipo.Text = lector["TipoEquipo"].ToString();
                        tModelo.Text = lector["Modelo"].ToString();
                        tUsuarioID.Text = lector["UsuarioID"].ToString();

                        lMensaje.Text = "Equipo encontrado correctamente.";
                    }
                    else
                    {
                        lMensaje.Text = "No se encontro el equipo.";
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