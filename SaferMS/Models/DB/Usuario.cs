using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace SaferMS.Models.DB
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int NumEmpleado { get; set; }
        
        [Required(ErrorMessage = "Campo obligatorio"), EmailAddress(ErrorMessage = "Coloca una cuenta de correo valida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int Idsexo { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int IdPuesto { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Posición { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public int IdDepartamento { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Privilegio { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        public string Contraseña { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; }
        public virtual Puesto IdPuestoNavigation { get; set; }
        public virtual Sexo IdsexoNavigation { get; set; }
    }
}
