using System;
using System.Collections.Generic;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class Area
    {
        public Area()
        {
            RegistroObservacions = new HashSet<RegistroObservacion>();
        }

        public int IdArea { get; set; }
        public string NomArea { get; set; }

        public virtual ICollection<RegistroObservacion> RegistroObservacions { get; set; }
    }
}
