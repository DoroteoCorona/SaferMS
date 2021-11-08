using System;
using System.Collections.Generic;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class RegistroObservacion
    {
        public int IdObservacion { get; set; }
        public int FolioObservacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public int IdArea { get; set; }
        public string ObservacionA { get; set; }
        public int PersonasRetroalimentadas { get; set; }
        public string DescripcionObservacion { get; set; }
        public string AccionesRealizadas { get; set; }
        public string TipoObservacion { get; set; }
        public int IdAspecto { get; set; }
        public int IdComportamiento { get; set; }
        public string Criticidad { get; set; }
        public string ResponsableSeguimiento { get; set; }
        public byte[] EvidenciaObservacion { get; set; }
        public string PlanAccion { get; set; }
        public string TiempoSolucion { get; set; }
        public decimal PresupuestoRequerido { get; set; }
        public DateTime FechaCompromiso { get; set; }
        public string ComentariosObservacion { get; set; }
        public byte[] EvidenciaCierre { get; set; }

        public virtual Aspecto IdObservacion1 { get; set; }
        public virtual Comportamiento IdObservacion2 { get; set; }
        public virtual Usuario IdObservacion3 { get; set; }
        public virtual Area IdObservacionNavigation { get; set; }
    }
}
