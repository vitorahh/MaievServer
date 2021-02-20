using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MaievEntityFramework.Models.DataBaseModels;

#nullable disable

namespace MaievEntityFramework.Models.Context
{
    public partial class maievdatabaseContext : DbContext
    {
        public maievdatabaseContext()
        {
        }

        public maievdatabaseContext(DbContextOptions<maievdatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TB_LE_LANCE> TB_LE_LANCEs { get; set; }
        public virtual DbSet<TB_LE_PRODUTO> TB_LE_PRODUTOs { get; set; }
        public virtual DbSet<TB_LE_USUARIO> TB_LE_USUARIOs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=den1.mssql8.gear.host;Initial Catalog=maievdatabase;persist security info=True;user id=maievdatabase;password=Ab6A4i5P_nv-;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TB_LE_LANCE>(entity =>
            {
                entity.HasKey(e => e.ID_LANCE)
                    .HasName("PK__TB_LE_LA__D97AA3DF92D83C3A");

                entity.HasOne(d => d.ID_PRODUTONavigation)
                    .WithMany(p => p.TB_LE_LANCEs)
                    .HasForeignKey(d => d.ID_PRODUTO)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_PRODUTO");

                entity.HasOne(d => d.ID_USUARIONavigation)
                    .WithMany(p => p.TB_LE_LANCEs)
                    .HasForeignKey(d => d.ID_USUARIO)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ID_USUARIO");
            });

            modelBuilder.Entity<TB_LE_PRODUTO>(entity =>
            {
                entity.HasKey(e => e.ID_PRODUTO)
                    .HasName("PK__TB_LE_PR__69B28A52E35414E5");

                entity.Property(e => e.DS_NOME).IsUnicode(false);
            });

            modelBuilder.Entity<TB_LE_USUARIO>(entity =>
            {
                entity.HasKey(e => e.ID_USUARIO)
                    .HasName("PK__TB_LE_US__91136B90F9CC3E8B");

                entity.Property(e => e.DS_LOGIN).IsUnicode(false);

                entity.Property(e => e.DS_SENHA).IsUnicode(false);

                entity.Property(e => e.DS_USUARIO).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
