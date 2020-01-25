using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Registro_del_Personal.Entidades
{
    public class Persona
    {
        [Key]
        public int PersonaID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Persona()
        {
            PersonaID = 0;
            Nombre = String.Empty;
            Telefono = String.Empty;
            Cedula = String.Empty;
            Direccion = String.Empty;
            FechaNacimiento = DateTime.Now;
        }
    }
}
