using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebGz.Models
{
    public partial class bdgzContext : DbContext
    {
        public bdgzContext()
        {
        }

        public bdgzContext(DbContextOptions<bdgzContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Provedor> Provedors { get; set; }
        public virtual DbSet<Cliente> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;database=bdgz;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.19-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente)
                    .HasName("PRIMARY");

                entity.ToTable("cliente");

                entity.HasComment("Informacion de los clientes");

                entity.Property(e => e.Idcliente)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDCliente");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.CC)
                    .HasColumnType("int(12) unsigned")
                    .HasColumnName("C.C");

                entity.Property(e => e.Celular)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30);
            });


            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.Property(e => e.Id)
                    .HasColumnType("int(10)")
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("nombre");

                entity.Property(e => e.Apodo)
                    .HasColumnType("varchar(25)")
                    .HasColumnName("apodo");

                entity.Property(e => e.Contraseña)
                    .HasColumnType("varchar (10)")
                    .HasColumnName("contraseña");
            });
            

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => new { e.Idcliente, e.Idproducto })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("compras");

                entity.HasIndex(e => e.Idproducto, "FK_IDproducto");

                entity.Property(e => e.Idcliente)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDcliente");

                entity.Property(e => e.Idproducto)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDproducto");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDcliente");

                entity.HasOne(d => d.IdproductoNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.Idproducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDproducto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Idproducto)
                    .HasName("PRIMARY");

                entity.ToTable("producto");

                entity.HasIndex(e => e.Idprovedor, "FK_IDprovedor");

                entity.Property(e => e.Idproducto)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("IDProducto");

                entity.Property(e => e.Idprovedor)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDprovedor");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdprovedorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.Idprovedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IDprovedor");
            });

            modelBuilder.Entity<Provedor>(entity =>
            {
                entity.HasKey(e => e.Idprovedor)
                    .HasName("PRIMARY");

                entity.ToTable("provedor");

                entity.Property(e => e.Idprovedor)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("IDProvedor");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
