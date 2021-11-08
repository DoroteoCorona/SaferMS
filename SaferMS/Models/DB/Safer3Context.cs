using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SaferMS.Models.DB
{
    public partial class Safer3Context : DbContext
    {
        public Safer3Context()
        {
        }

        public Safer3Context(DbContextOptions<Safer3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Aspecto> Aspectos { get; set; }
        public virtual DbSet<Comportamiento> Comportamientos { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Puesto> Puestos { get; set; }
        public virtual DbSet<RegistroObservacion> RegistroObservacions { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GUUO8O4\\SQLEXPRESS; Database=Safer3; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea);

                entity.ToTable("area");

                entity.Property(e => e.IdArea).HasColumnName("idArea");

                entity.Property(e => e.NomArea)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomArea");
            });

            modelBuilder.Entity<Aspecto>(entity =>
            {
                entity.HasKey(e => e.IdAspecto);

                entity.ToTable("aspecto");

                entity.Property(e => e.IdAspecto).HasColumnName("idAspecto");

                entity.Property(e => e.NomAspecto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomAspecto");
            });

            modelBuilder.Entity<Comportamiento>(entity =>
            {
                entity.HasKey(e => e.IdComportamiento);

                entity.ToTable("comportamiento");

                entity.Property(e => e.IdComportamiento).HasColumnName("idComportamiento");

                entity.Property(e => e.NomComportamiento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomComportamiento");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento);

                entity.ToTable("departamento");

                entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");

                entity.Property(e => e.NomDepartamento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomDepartamento");
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.HasKey(e => e.IdPuesto);

                entity.ToTable("puesto");

                entity.Property(e => e.IdPuesto).HasColumnName("idPuesto");

                entity.Property(e => e.NomPuesto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nomPuesto");
            });

            modelBuilder.Entity<RegistroObservacion>(entity =>
            {
                entity.HasKey(e => e.IdObservacion);

                entity.ToTable("registroObservacion");

                entity.Property(e => e.IdObservacion)
                    .ValueGeneratedNever()
                    .HasColumnName("idObservacion");

                entity.Property(e => e.AccionesRealizadas)
                    .IsRequired()
                    .HasColumnName("accionesRealizadas");

                entity.Property(e => e.ComentariosObservacion)
                    .IsRequired()
                    .HasColumnName("comentariosObservacion");

                entity.Property(e => e.Criticidad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("criticidad");

                entity.Property(e => e.DescripcionObservacion)
                    .IsRequired()
                    .HasColumnName("descripcionObservacion");

                entity.Property(e => e.EvidenciaCierre)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("evidenciaCierre");

                entity.Property(e => e.EvidenciaObservacion)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("evidenciaObservacion");

                entity.Property(e => e.FechaCompromiso)
                    .HasColumnType("date")
                    .HasColumnName("fechaCompromiso");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion");

                entity.Property(e => e.FolioObservacion)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("folioObservacion");

                entity.Property(e => e.IdArea).HasColumnName("idArea");

                entity.Property(e => e.IdAspecto).HasColumnName("idAspecto");

                entity.Property(e => e.IdComportamiento).HasColumnName("idComportamiento");

                entity.Property(e => e.ObservacionA)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PersonasRetroalimentadas).HasColumnName("personasRetroalimentadas");

                entity.Property(e => e.PlanAccion)
                    .IsRequired()
                    .HasColumnName("planAccion");

                entity.Property(e => e.PresupuestoRequerido)
                    .HasColumnType("money")
                    .HasColumnName("presupuestoRequerido");

                entity.Property(e => e.ResponsableSeguimiento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("responsableSeguimiento");

                entity.Property(e => e.TiempoSolucion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tiempoSolucion");

                entity.Property(e => e.TipoObservacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("tipoObservacion");

                entity.Property(e => e.UsuarioCreacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("usuarioCreacion");

                entity.HasOne(d => d.IdObservacionNavigation)
                    .WithOne(p => p.RegistroObservacion)
                    .HasForeignKey<RegistroObservacion>(d => d.IdObservacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registroObservacion_area");

                entity.HasOne(d => d.IdObservacion1)
                    .WithOne(p => p.RegistroObservacion)
                    .HasForeignKey<RegistroObservacion>(d => d.IdObservacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registroObservacion_aspecto");

                entity.HasOne(d => d.IdObservacion2)
                    .WithOne(p => p.RegistroObservacion)
                    .HasForeignKey<RegistroObservacion>(d => d.IdObservacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registroObservacion_comportamiento");

                entity.HasOne(d => d.IdObservacion3)
                    .WithOne(p => p.RegistroObservacion)
                    .HasForeignKey<RegistroObservacion>(d => d.IdObservacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_registroObservacion_usuario");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.HasKey(e => e.IdSexo);

                entity.ToTable("sexo");

                entity.Property(e => e.IdSexo).HasColumnName("idSexo");

                entity.Property(e => e.Genero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("genero");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuario");

                entity.Property(e => e.IdUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idUsuario");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Contraseña)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("contraseña");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");

                entity.Property(e => e.IdPuesto).HasColumnName("idPuesto");

                entity.Property(e => e.Idsexo).HasColumnName("idsexo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre");

                entity.Property(e => e.NumEmpleado).HasColumnName("numEmpleado");

                entity.Property(e => e.Posición)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("posición");

                entity.Property(e => e.Privilegio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("privilegio");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Usuario>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuario_departamento");

                entity.HasOne(d => d.IdUsuario1)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Usuario>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuario_puesto");

                entity.HasOne(d => d.IdUsuario2)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Usuario>(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_usuario_sexo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
