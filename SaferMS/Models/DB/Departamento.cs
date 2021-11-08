using System;
using System.Collections.Generic;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class Departamento
    {
        public int IdDepartamento { get; set; }
        public string NomDepartamento { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
