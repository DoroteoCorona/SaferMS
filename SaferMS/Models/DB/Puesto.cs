using System;
using System.Collections.Generic;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class Puesto
    {
        public Puesto()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdPuesto { get; set; }
        public string NomPuesto { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
