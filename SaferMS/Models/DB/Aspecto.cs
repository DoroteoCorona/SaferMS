using System;
using System.Collections.Generic;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class Aspecto
    {
        public int IdAspecto { get; set; }
        public string NomAspecto { get; set; }

        public virtual RegistroObservacion RegistroObservacion { get; set; }
    }
}
