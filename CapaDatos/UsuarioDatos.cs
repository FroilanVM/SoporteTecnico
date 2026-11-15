using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoporteTecnico
{
    public class UsuarioDatos
    {
        private int usuarioID;  // Variable para almacenar el ID del usuario

        public int UsuarioID // Propiedad para consultar y modificar el ID
        {
            get { return usuarioID; }
            set { usuarioID = value; }
        }

        private string nombre;  // Variable para almacenar el nombre del usuario

        public string Nombre 
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string correoElectronico;  // Variable para almacenar el correo electrónico del usuario

        public string CorreoElectronico
        {
            get { return correoElectronico; }
            set { correoElectronico = value; }
        }

        private string telefono; // Variable para almacenar el teléfono del usuario

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
    }
}