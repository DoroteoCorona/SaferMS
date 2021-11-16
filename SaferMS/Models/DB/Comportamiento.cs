using System;
using System.Collections.Generic;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class Comportamiento
    {
        public Comportamiento()
        {
            RegistroObservacions = new HashSet<RegistroObservacion>();
        }

        public int IdComportamiento { get; set; }
        public string NomComportamiento { get; set; }

        public virtual ICollection<RegistroObservacion> RegistroObservacions { get; set; }
    }
}
