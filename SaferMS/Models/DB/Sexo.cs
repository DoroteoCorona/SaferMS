using System;
using System.Collections.Generic;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class Sexo
    {
        public Sexo()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdSexo { get; set; }
        public string Genero { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
