using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infraestructura.Models
{
    public partial class testContext : DbContext
    {
        public testContext()
        {
        }

        public testContext(DbContextOptions<testContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<TipoPermiso> TipoPermisos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.Property(e => e.Id).HasComment("Id de permiso");

                entity.Property(e => e.ApellidoEmpleado)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("Apellido de empleado");

                entity.Property(e => e.FechaPermiso)
                    .HasColumnType("date")
                    .HasComment("Fecha de registro permiso");

                entity.Property(e => e.NombreEmpleado)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("Nombre de empleado");

                entity.Property(e => e.TipoPermiso).HasComment("Id de tipo de permiso");

                entity.HasOne(d => d.TipoPermisoNavigation)
                    .WithMany(p => p.Permisos)
                    .HasForeignKey(d => d.TipoPermiso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Id_Permiso_Tipo_1");
            });

            modelBuilder.Entity<TipoPermiso>(entity =>
            {
                entity.Property(e => e.Id).HasComment("Id de tipo de permiso");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("Descripcion de permiso");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
