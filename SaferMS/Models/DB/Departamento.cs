using System;
using System.Collections.Generic;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class Departamento
    {
        public Departamento()
        {
            RegistroObservacions = new HashSet<RegistroObservacion>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdDepartamento { get; set; }
        public string NomDepartamento { get; set; }

        public virtual ICollection<RegistroObservacion> RegistroObservacions { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
