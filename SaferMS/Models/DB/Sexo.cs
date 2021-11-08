using System;
using System.Collections.Generic;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class Sexo
    {
        public int IdSexo { get; set; }
        public string Genero { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
