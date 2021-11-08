using System;
using System.Collections.Generic;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int NumEmpleado { get; set; }
        public string Email { get; set; }
        public int Idsexo { get; set; }
        public int IdPuesto { get; set; }
        public string Posición { get; set; }
        public int IdDepartamento { get; set; }
        public string Privilegio { get; set; }
        public string Contraseña { get; set; }

        public virtual Puesto IdUsuario1 { get; set; }
        public virtual Sexo IdUsuario2 { get; set; }
        public virtual Departamento IdUsuarioNavigation { get; set; }
        public virtual RegistroObservacion RegistroObservacion { get; set; }
    }
}
