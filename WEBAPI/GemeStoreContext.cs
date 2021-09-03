using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WEBAPI
{
    public partial class GemeStoreContext : DbContext
    {
        public GemeStoreContext()
        {
        }

        public GemeStoreContext(DbContextOptions<GemeStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Key1> Keys { get; set; }
        public virtual DbSet<StyleFoGame> StyleFoGames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=WIN-TUD2DUAF5IN\\SQLEXPRESS;Database=GemeStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Stud).HasMaxLength(200);
            });

            modelBuilder.Entity<Key1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Key1");

                entity.Property(e => e.Idgem).HasColumnName("IDgem");

                entity.Property(e => e.Idsyle).HasColumnName("IDSyle");

                entity.HasOne(d => d.IdgemNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idgem)
                    .HasConstraintName("FK_Key1_Game");

                entity.HasOne(d => d.IdsyleNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idsyle)
                    .HasConstraintName("FK_Key1_StyleFoGame");
            });

            modelBuilder.Entity<StyleFoGame>(entity =>
            {
                entity.ToTable("StyleFoGame");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
