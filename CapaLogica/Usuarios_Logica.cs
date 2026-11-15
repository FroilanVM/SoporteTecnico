using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace SoporteTecnico.CapaLogica
{
    public class Usuarios_Logica
    {
        // Metodo para agregar un nuevo usuario a la base de datos
        public static int AgregarUsuario(int usuarioID, string nombre, string correoElectronico, string telefono)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();

            try
            {
                ConexionBasedeDatos objConexion = new ConexionBasedeDatos();

                using (Conn = objConexion.ObtenerConexion())
                {
                    Conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Usuarios (UsuarioID, Nombre, CorreoElectronico, Telefono) VALUES (@usuarioID, @nombre, @correoElectronico, @telefono)", Conn)
                    {
                        CommandType = CommandType.Text
                    };

                    // Agregar los parametros necesarios para guardar el usuario
                    cmd.Parameters.Add(new SqlParameter("@usuarioID", usuarioID));
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@correoElectronico", correoElectronico));
                    cmd.Parameters.Add(new SqlParameter("@telefono", telefono));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                retorno = 0;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        // Metodo para modificar los datos de un usuario existente
        public static int ModificarUsuario(int usuarioID, string nombre, string correoElectronico, string telefono)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();

            try
            {
                ConexionBasedeDatos objConexion = new ConexionBasedeDatos();

                using (Conn = objConexion.ObtenerConexion())
                {
                    Conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Usuarios SET Nombre = @nombre, CorreoElectronico = @correoElectronico, Telefono = @telefono WHERE UsuarioID = @usuarioID", Conn)
                    {
                        CommandType = CommandType.Text
                    };

                    // Agregar los parametros necesarios para modificar el usuario
                    cmd.Parameters.Add(new SqlParameter("@usuarioID", usuarioID));
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@correoElectronico", correoElectronico));
                    cmd.Parameters.Add(new SqlParameter("@telefono", telefono));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                retorno = 0;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }


        // Metodo para eliminar un usuario de la base de datos
        public static int EliminarUsuario(int usuarioID)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();

            try
            {
                ConexionBasedeDatos objConexion = new ConexionBasedeDatos();

                using (Conn = objConexion.ObtenerConexion())
                {
                    Conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Usuarios WHERE UsuarioID = @usuarioID", Conn)
                    {
                        CommandType = CommandType.Text
                    };

                    // Agregar el parametro para identificar al usuario que se desea eliminar
                    cmd.Parameters.Add(new SqlParameter("@usuarioID", usuarioID));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                retorno = 0;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        // Metodo para consultar un usuario por su identificacion
        public static SqlDataReader ConsultarUsuario(int usuarioID)
        {
            ConexionBasedeDatos objConexion = new ConexionBasedeDatos();

            SqlConnection Conn = objConexion.ObtenerConexion();

            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Usuarios WHERE UsuarioID = @usuarioID", Conn);

            // Agregar el parametro para identificar al usuario que se desea consultar
            cmd.Parameters.Add(new SqlParameter("@usuarioID", usuarioID));

            Conn.Open();

            // Ejecutar la consulta y devolver los datos encontrados
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

    }
}