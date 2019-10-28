using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace grbackend.Models
{
    public partial class grdbContext : DbContext
    {
        public grdbContext()
        {
        }

        public grdbContext(DbContextOptions<grdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anuncio> Anuncio { get; set; }
        public virtual DbSet<Banca> Banca { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<Cotizacion> Cotizacion { get; set; }
        public virtual DbSet<Evaluacion> Evaluacion { get; set; }
        public virtual DbSet<Historialtecnico> Historialtecnico { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<Tecnico> Tecnico { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("User ID = postgres;Password=M3nd3z;Server=localhost;Port=5432;Database=grdb;Integrated Security=true; Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anuncio>(entity =>
            {
                entity.ToTable("anuncio");

                entity.Property(e => e.Anuncioid)
                    .HasColumnName("anuncioid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Mensaje)
                    .IsRequired()
                    .HasColumnName("mensaje")
                    .HasColumnType("character varying");

                entity.Property(e => e.Tecnicoid).HasColumnName("tecnicoid");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Tecnico)
                    .WithMany(p => p.Anuncio)
                    .HasForeignKey(d => d.Tecnicoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tecnicoid");
            });

            modelBuilder.Entity<Banca>(entity =>
            {
                entity.ToTable("banca");

                entity.Property(e => e.Bancaid)
                    .HasColumnName("bancaid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Banco)
                    .IsRequired()
                    .HasColumnName("banco")
                    .HasColumnType("character varying");

                entity.Property(e => e.Cuenta)
                    .IsRequired()
                    .HasColumnName("cuenta")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.Categoriaid)
                    .HasColumnName("categoriaid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.Property(e => e.Clienteid)
                    .HasColumnName("clienteid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Bancaid).HasColumnName("bancaid");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasColumnType("character varying");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasColumnType("character varying");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasColumnType("character varying");

                entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");

                entity.HasOne(d => d.Banca)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.Bancaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bancaid");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.Usuarioid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuarioid");
            });

            modelBuilder.Entity<Contrato>(entity =>
            {
                entity.ToTable("contrato");

                entity.Property(e => e.Contratoid)
                    .HasColumnName("contratoid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("character varying");

                entity.Property(e => e.Tecnicoid).HasColumnName("tecnicoid");

                entity.HasOne(d => d.Tecnico)
                    .WithMany(p => p.Contrato)
                    .HasForeignKey(d => d.Tecnicoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tecnicoid");
            });

            modelBuilder.Entity<Cotizacion>(entity =>
            {
                entity.ToTable("cotizacion");

                entity.Property(e => e.Cotizacionid)
                    .HasColumnName("cotizacionid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Clienteid).HasColumnName("clienteid");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Cotizacion)
                    .HasForeignKey(d => d.Clienteid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clienteid");
            });

            modelBuilder.Entity<Evaluacion>(entity =>
            {
                entity.ToTable("evaluacion");

                entity.Property(e => e.Evaluacionid)
                    .HasColumnName("evaluacionid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Categoriaid).HasColumnName("categoriaid");

                entity.Property(e => e.Clienteid).HasColumnName("clienteid");

                entity.Property(e => e.Comentario)
                    .IsRequired()
                    .HasColumnName("comentario")
                    .HasColumnType("character varying");

                entity.Property(e => e.Puntuacion).HasColumnName("puntuacion");

                entity.Property(e => e.Tecnicoid).HasColumnName("tecnicoid");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Evaluacion)
                    .HasForeignKey(d => d.Categoriaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_categoriaid");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Evaluacion)
                    .HasForeignKey(d => d.Clienteid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clienteid");

                entity.HasOne(d => d.Tecnico)
                    .WithMany(p => p.Evaluacion)
                    .HasForeignKey(d => d.Tecnicoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tecnicoid");
            });

            modelBuilder.Entity<Historialtecnico>(entity =>
            {
                entity.ToTable("historialtecnico");

                entity.Property(e => e.Historialtecnicoid)
                    .HasColumnName("historialtecnicoid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Servicioid).HasColumnName("servicioid");

                entity.Property(e => e.Tecnicoid).HasColumnName("tecnicoid");

                entity.HasOne(d => d.Servicio)
                    .WithMany(p => p.Historialtecnico)
                    .HasForeignKey(d => d.Servicioid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_servicioid");

                entity.HasOne(d => d.Tecnico)
                    .WithMany(p => p.Historialtecnico)
                    .HasForeignKey(d => d.Tecnicoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tecnicoid");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.ToTable("pago");

                entity.Property(e => e.Pagoid)
                    .HasColumnName("pagoid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Cleinteid).HasColumnName("cleinteid");

                entity.Property(e => e.Fechadeexpiracion)
                    .IsRequired()
                    .HasColumnName("fechadeexpiracion")
                    .HasColumnType("character varying");

                entity.Property(e => e.Monto).HasColumnName("monto");

                entity.Property(e => e.Servicioid).HasColumnName("servicioid");

                entity.Property(e => e.Tarjeta)
                    .IsRequired()
                    .HasColumnName("tarjeta")
                    .HasColumnType("character varying");

                entity.Property(e => e.Tarjetahabiente)
                    .IsRequired()
                    .HasColumnName("tarjetahabiente")
                    .HasColumnType("character varying");

                entity.Property(e => e.Tecnicoid).HasColumnName("tecnicoid");

                entity.HasOne(d => d.Cleinte)
                    .WithMany(p => p.Pago)
                    .HasForeignKey(d => d.Cleinteid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clienteid");

                entity.HasOne(d => d.Servicio)
                    .WithMany(p => p.Pago)
                    .HasForeignKey(d => d.Servicioid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_servicioid");

                entity.HasOne(d => d.Tecnico)
                    .WithMany(p => p.Pago)
                    .HasForeignKey(d => d.Tecnicoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tecnicoid");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.ToTable("servicio");

                entity.Property(e => e.Servicioid)
                    .HasColumnName("servicioid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Categoriaid).HasColumnName("categoriaid");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Tecnico>(entity =>
            {
                entity.ToTable("tecnico");

                entity.Property(e => e.Tecnicoid)
                    .HasColumnName("tecnicoid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Bancaid).HasColumnName("bancaid");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasColumnType("character varying");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");

                entity.Property(e => e.Servicioid).HasColumnName("servicioid");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasColumnType("character varying");

                entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");

                entity.HasOne(d => d.Banca)
                    .WithMany(p => p.Tecnico)
                    .HasForeignKey(d => d.Bancaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_bancaid");

                entity.HasOne(d => d.Servicio)
                    .WithMany(p => p.Tecnico)
                    .HasForeignKey(d => d.Servicioid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_servicioid");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Tecnico)
                    .HasForeignKey(d => d.Usuarioid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuarioid");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Usuarioid)
                    .HasColumnName("usuarioid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasColumnType("character varying");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasColumnType("character varying");

                entity.Property(e => e.Cuenta).HasColumnName("cuenta");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");

                entity.Property(e => e.Tipo).HasColumnName("tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
