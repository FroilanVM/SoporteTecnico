using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SoporteTecnico.CapaLogica
{
    public class Equipos_Logica
    {
        // Metodo para agregar un nuevo equipo
        public static int AgregarEquipo(int equipoID, string tipoEquipo, string modelo, int usuarioID)
        {
            ConexionBasedeDatos objConexion = new ConexionBasedeDatos();

            using (SqlConnection Conn = objConexion.ObtenerConexion())
            {
                try
                {
                    Conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Equipos (EquipoID, TipoEquipo, Modelo, UsuarioID) VALUES (@equipoID, @tipoEquipo, @modelo, @usuarioID)", Conn);

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@equipoID", equipoID);
                    cmd.Parameters.AddWithValue("@tipoEquipo", tipoEquipo);
                    cmd.Parameters.AddWithValue("@modelo", modelo);
                    cmd.Parameters.AddWithValue("@usuarioID", usuarioID);

                    int resultado = cmd.ExecuteNonQuery();

                    return resultado;
                }
                catch (SqlException)
                {
                    return 0;
                }
            }
        }

        // Metodo para modificar un equipo existente
        public static int ModificarEquipo(int equipoID, string tipoEquipo, string modelo, int usuarioID)
        {
            ConexionBasedeDatos objConexion = new ConexionBasedeDatos();

            using (SqlConnection Conn = objConexion.ObtenerConexion())
            {
                try
                {
                    Conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Equipos SET TipoEquipo = @tipoEquipo, Modelo = @modelo, UsuarioID = @usuarioID WHERE EquipoID = @equipoID", Conn);

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@equipoID", equipoID);
                    cmd.Parameters.AddWithValue("@tipoEquipo", tipoEquipo);
                    cmd.Parameters.AddWithValue("@modelo", modelo);
                    cmd.Parameters.AddWithValue("@usuarioID", usuarioID);

                    int resultado = cmd.ExecuteNonQuery();

                    return resultado;
                }
                catch (SqlException)
                {
                    return 0;
                }
            }
        }

        // Metodo para eliminar un equipo
        public static int EliminarEquipo(int equipoID)
        {
            ConexionBasedeDatos objConexion = new ConexionBasedeDatos();

            using (SqlConnection Conn = objConexion.ObtenerConexion())
            {
                try
                {
                    Conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Equipos WHERE EquipoID = @equipoID", Conn);

                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@equipoID", equipoID);

                    int resultado = cmd.ExecuteNonQuery();

                    return resultado;
                }
                catch (SqlException)
                {
                    return 0;
                }
            }
        }

        // Metodo para consultar un equipo
        public static SqlDataReader ConsultarEquipo(int equipoID)
        {
            ConexionBasedeDatos objConexion = new ConexionBasedeDatos();

            SqlConnection Conn = objConexion.ObtenerConexion();

            try
            {
                Conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT * FROM Equipos WHERE EquipoID = @equipoID", Conn);

                cmd.Parameters.AddWithValue("@equipoID", equipoID);

                cmd.CommandType = CommandType.Text;

                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException)
            {
                Conn.Close();
                return null;
            }
        }
    }
}