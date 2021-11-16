using System;
using System.Collections.Generic;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class Aspecto
    {
        public Aspecto()
        {
            RegistroObservacions = new HashSet<RegistroObservacion>();
        }

        public int IdAspecto { get; set; }
        public string NomAspecto { get; set; }

        public virtual ICollection<RegistroObservacion> RegistroObservacions { get; set; }
    }
}
