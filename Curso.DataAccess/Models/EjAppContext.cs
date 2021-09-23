using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Curso.DataAccess.Models
{
    public partial class EjAppContext : DbContext
    {
        public EjAppContext()
        {
        }

        public EjAppContext(DbContextOptions<EjAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CategoriaProducto> CategoriaProducto { get; set; }
        public virtual DbSet<ClienteTipo> ClienteTipo { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<ClientesLog> ClientesLog { get; set; }
        public virtual DbSet<Compras> Compras { get; set; }
        public virtual DbSet<ComprasDetalle> ComprasDetalle { get; set; }
        public virtual DbSet<FormaDePago> FormaDePago { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<PersonaLog> PersonaLog { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<PersonasSubTipo> PersonasSubTipo { get; set; }
        public virtual DbSet<PersonasTipo> PersonasTipo { get; set; }
        public virtual DbSet<ProductoSubTipo> ProductoSubTipo { get; set; }
        public virtual DbSet<ProductoTipo> ProductoTipo { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }
        public virtual DbSet<ProveedoresCategoria> ProveedoresCategoria { get; set; }
        public virtual DbSet<Stock> Stock { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
        public virtual DbSet<VentasDetalle> VentasDetalle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<CategoriaProducto>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaProducto)
                    .HasName("PK_CategoriaProducto_1");

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ClienteTipo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoriaId).HasColumnName("Categoria_ID");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Detalles)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Borrado).HasColumnName("borrado");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.HasOne(d => d.ClienteTipo)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.ClienteTipoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Clientes_ClienteTipo");
            });

            modelBuilder.Entity<ClientesLog>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Borrado).HasColumnName("borrado");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.IdUsuario).HasMaxLength(450);

                entity.Property(e => e.Localidad).HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.ClientesLog)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientesLog_Clientes");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.ClientesLog)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_ClientesLog_AspNetUsers");
            });

            modelBuilder.Entity<Compras>(entity =>
            {
                entity.HasKey(e => e.IdCompras);

                entity.Property(e => e.IdCompras).HasColumnName("idCompras");

                entity.Property(e => e.Borrado).HasColumnName("borrado");

                entity.Property(e => e.Comentarios).HasMaxLength(150);

                entity.Property(e => e.FechaCompra)
                    .HasColumnName("Fecha_compra")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCompraDetalle).HasColumnName("idCompraDetalle");

                entity.Property(e => e.Idformapago).HasColumnName("idformapago");

                entity.Property(e => e.NroCompra).HasColumnName("Nro_Compra");

                entity.Property(e => e.PuntoDeVenta)
                    .HasColumnName("Punto_de_venta")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdCompraDetalleNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdCompraDetalle)
                    .HasConstraintName("FK_Compras_ComprasDetalle");

                entity.HasOne(d => d.IdformapagoNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.Idformapago)
                    .HasConstraintName("FK_Compras_FormaDePago");
            });

            modelBuilder.Entity<ComprasDetalle>(entity =>
            {
                entity.HasKey(e => e.IdComprasDetalle);

                entity.Property(e => e.IdComprasDetalle)
                    .HasColumnName("idComprasDetalle")
                    .ValueGeneratedNever();

                entity.Property(e => e.Borrado).HasColumnName("borrado");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FormaDePago>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descripción)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<PersonaLog>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.FechaDeNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.PersonaLog)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonaLog_Personas");
            });

            modelBuilder.Entity<Personas>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Borrado).HasColumnName("borrado");

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.FechaDeNacimiento).HasColumnType("datetime");

                entity.Property(e => e.IdSubTipoPersona).HasColumnName("idSubTipoPersona");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdSubTipoPersonaNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdSubTipoPersona)
                    .HasConstraintName("FK_Personas_PersonasSubTipo");

                entity.HasOne(d => d.IdTipoPersonaNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdTipoPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Personas_PersonasTipo");
            });

            modelBuilder.Entity<PersonasSubTipo>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdPersonasTipoNavigation)
                    .WithMany(p => p.PersonasSubTipo)
                    .HasForeignKey(d => d.IdPersonasTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonasSubTipo_PersonasTipo");
            });

            modelBuilder.Entity<PersonasTipo>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductoSubTipo>(entity =>
            {
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.IdProductoTipoNavigation)
                    .WithMany(p => p.ProductoSubTipo)
                    .HasForeignKey(d => d.IdProductoTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductoSubTipo_ProductoTipo");
            });

            modelBuilder.Entity<ProductoTipo>(entity =>
            {
                entity.HasKey(e => e.IdProductoTipo);

                entity.Property(e => e.Borrado).HasColumnName("borrado");

                entity.Property(e => e.CampoNuevo)
                    .IsRequired()
                    .HasColumnName("campoNuevo")
                    .HasMaxLength(50);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdProductoCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdProductoCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Productos_CategoriaProducto");

                entity.HasOne(d => d.IdProductoSubTipoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdProductoSubTipo)
                    .HasConstraintName("FK_Productos_ProductoSubTipo");

                entity.HasOne(d => d.IdProductoTipoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdProductoTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Productos_ProductoTipo");
            });

            modelBuilder.Entity<Proveedores>(entity =>
            {
                entity.Property(e => e.Domicilio).HasMaxLength(50);

                entity.Property(e => e.FechaInscripcion).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdCategoriaProveedoresNavigation)
                    .WithMany(p => p.Proveedores)
                    .HasForeignKey(d => d.IdCategoriaProveedores)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Proveedores_ProveedoresCategoria");
            });

            modelBuilder.Entity<ProveedoresCategoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoriaProveedores);

                entity.Property(e => e.DescripcionCategoria)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NombreCategoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.Borrado).HasColumnName("borrado");

                entity.Property(e => e.Stock1).HasColumnName("Stock");
            });

            modelBuilder.Entity<Ventas>(entity =>
            {
                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.HasOne(d => d.IdVentasDetalleNavigation)
                    .WithMany(p => p.Ventas)
                    .HasForeignKey(d => d.IdVentasDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ventas_VentasDetalle");
            });

            modelBuilder.Entity<VentasDetalle>(entity =>
            {
                entity.HasKey(e => e.IdDetalleVenta)
                    .HasName("PK_DetalleVenta");

                entity.Property(e => e.Borrado).HasDefaultValueSql("((0))");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioUnitario).HasColumnType("money");

                entity.Property(e => e.Subtotal).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
