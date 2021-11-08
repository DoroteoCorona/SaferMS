using System;
using System.Collections.Generic;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class Area
    {
        public int IdArea { get; set; }
        public string NomArea { get; set; }

        public virtual RegistroObservacion RegistroObservacion { get; set; }
    }
}
