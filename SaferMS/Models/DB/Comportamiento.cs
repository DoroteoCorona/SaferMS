using System;
using System.Collections.Generic;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class Comportamiento
    {
        public int IdComportamiento { get; set; }
        public string NomComportamiento { get; set; }

        public virtual RegistroObservacion RegistroObservacion { get; set; }
    }
}
