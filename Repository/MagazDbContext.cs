using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Config.Repository.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Config.Repository
{
    public partial class MagazDbContext : DbContext
    {
        public MagazDbContext()
        {
        }

        public MagazDbContext(DbContextOptions<MagazDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Corpus> Corpus { get; set; }
        public virtual DbSet<Ddr> Ddr { get; set; }
        public virtual DbSet<Memory> Memory { get; set; }
        public virtual DbSet<Motherboard> Motherboard { get; set; }
        public virtual DbSet<Ohlad> Ohlad { get; set; }
        public virtual DbSet<OhladWater> OhladWater { get; set; }
        public virtual DbSet<PowerBlock> PowerBlock { get; set; }
        public virtual DbSet<Processor> Processor { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Sborka> Sborka { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Videocard> Videocard { get; set; }
        public virtual DbSet<Zakaz> Zakaz { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-DS4KH2V;Initial Catalog=Magaz;Integrated Security=True; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Corpus>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Corpus")
                    .IsUnique();

                entity.Property(e => e.MotherSize).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.PowerBlockSize).IsUnicode(false);

                entity.Property(e => e.Size).IsUnicode(false);

                entity.Property(e => e.VideoSize).IsUnicode(false);
            });

            modelBuilder.Entity<Ddr>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_DDR")
                    .IsUnique();

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);
            });

            modelBuilder.Entity<Memory>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Memory")
                    .IsUnique();

                entity.Property(e => e.IdMemory).ValueGeneratedNever();

                entity.Property(e => e.Interface).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Motherboard>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Motherboard")
                    .IsUnique();

                entity.Property(e => e.Chipset).IsUnicode(false);

                entity.Property(e => e.Ddr).IsUnicode(false);

                entity.Property(e => e.M2).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Pci).IsFixedLength();

                entity.Property(e => e.Sata).IsUnicode(false);

                entity.Property(e => e.Socket).IsUnicode(false);

                entity.Property(e => e.Standart).IsUnicode(false);
            });

            modelBuilder.Entity<Ohlad>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Ohlad")
                    .IsUnique();

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Socket).IsUnicode(false);
            });

            modelBuilder.Entity<OhladWater>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Ohlad_water")
                    .IsUnique();

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Socket).IsUnicode(false);
            });

            modelBuilder.Entity<PowerBlock>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_PowerBlock")
                    .IsUnique();

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Sertificat).IsUnicode(false);

                entity.Property(e => e.Size).IsUnicode(false);
            });

            modelBuilder.Entity<Processor>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Processor")
                    .IsUnique();

                entity.Property(e => e.Ddr).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Socket).IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.NameRole)
                    .HasName("IX_Role")
                    .IsUnique();

                entity.Property(e => e.NameRole).IsUnicode(false);
            });

            modelBuilder.Entity<Sborka>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Sborka")
                    .IsUnique();

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.IdCorpusNavigation)
                    .WithMany(p => p.Sborka)
                    .HasForeignKey(d => d.IdCorpus)
                    .HasConstraintName("FK_Sborka_Corpus");

                entity.HasOne(d => d.IdDdrNavigation)
                    .WithMany(p => p.Sborka)
                    .HasForeignKey(d => d.IdDdr)
                    .HasConstraintName("FK_Sborka_DDR");

                entity.HasOne(d => d.IdMemoryNavigation)
                    .WithMany(p => p.Sborka)
                    .HasForeignKey(d => d.IdMemory)
                    .HasConstraintName("FK_Sborka_Memory");

                entity.HasOne(d => d.IdMotherboardNavigation)
                    .WithMany(p => p.Sborka)
                    .HasForeignKey(d => d.IdMotherboard)
                    .HasConstraintName("FK_Sborka_Motherboard");

                entity.HasOne(d => d.IdOhladNavigation)
                    .WithMany(p => p.Sborka)
                    .HasForeignKey(d => d.IdOhlad)
                    .HasConstraintName("FK_Sborka_Ohlad");

                entity.HasOne(d => d.IdOhladWaterNavigation)
                    .WithMany(p => p.Sborka)
                    .HasForeignKey(d => d.IdOhladWater)
                    .HasConstraintName("FK_Sborka_Ohlad_water");

                entity.HasOne(d => d.IdPowerblockNavigation)
                    .WithMany(p => p.Sborka)
                    .HasForeignKey(d => d.IdPowerblock)
                    .HasConstraintName("FK_Sborka_PowerBlock");

                entity.HasOne(d => d.IdProcessorNavigation)
                    .WithMany(p => p.Sborka)
                    .HasForeignKey(d => d.IdProcessor)
                    .HasConstraintName("FK_Sborka_Processor");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Sborka)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Sborka_User");

                entity.HasOne(d => d.IdVideocardNavigation)
                    .WithMany(p => p.Sborka)
                    .HasForeignKey(d => d.IdVideocard)
                    .HasConstraintName("FK_Sborka_Videocard");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Login)
                    .HasName("IX_User")
                    .IsUnique();

                entity.Property(e => e.Login).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            modelBuilder.Entity<Videocard>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("IX_Videocard")
                    .IsUnique();

                entity.Property(e => e.Gddr).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Zakaz>(entity =>
            {
                entity.Property(e => e.Adress).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.HasOne(d => d.IdSborkaNavigation)
                    .WithMany(p => p.Zakaz)
                    .HasForeignKey(d => d.IdSborka)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Zakaz_Sborka");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
