using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoporteTecnico.CapaDatos
{
    public class EquipoDatos
    {
        private int equipoID; // Variable para almacenar el ID del equipo

        public int EquipoID // Propiedad para consultar y modificar el ID
        {
            get { return equipoID; }
            set { equipoID = value; }
        }

        private string tipoEquipo; // Variable para almacenar el tipo de equipo

        public string TipoEquipo
        {
            get { return tipoEquipo; }
            set { tipoEquipo = value; }
        }

        private string modelo; // Variable para almacenar el modelo del equipo

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        private int usuarioID; // Variable para almacenar el ID del usuario relacionado

        public int UsuarioID
        {
            get { return usuarioID; }
            set { usuarioID = value; }
        }
    }
}