using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class RegistroObservacion
    {
        public int IdObservacion { get; set; }        
        public DateTime? FechaCreacion  { get; set; }
        public string UsuarioCreacion { get; set; }
        public int? IdArea { get; set; }
        public string ObservacionA { get; set; }
        public int? PersonasRetroalimentadas { get; set; }
        public string DescripcionObservacion { get; set; }
        public string AccionesRealizadas { get; set; }
        public string TipoObservacion { get; set; }
        public int? IdAspecto { get; set; }
        public int? IdComportamiento { get; set; }
        public string Criticidad { get; set; }
        public int? IdDepartamento { get; set; }
        public string PlanAccion { get; set; }
        public string TiempoSolucion { get; set; }
        public decimal? PresupuestoRequerido { get; set; }
        public DateTime? FechaCompromiso { get; set; }
        public string ComentariosObservacion { get; set; }

        public virtual Area IdAreaNavigation { get; set; }
        public virtual Aspecto IdAspectoNavigation { get; set; }
        public virtual Comportamiento IdComportamientoNavigation { get; set; }
        public virtual Departamento IdDepartamentoNavigation { get; set; }
    }
}
