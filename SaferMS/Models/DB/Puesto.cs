using System;
using System.Collections.Generic;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class Puesto
    {
        public int IdPuesto { get; set; }
        public string NomPuesto { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
