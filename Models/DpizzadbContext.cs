using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DpizzaProject.Models
{
    public partial class DpizzadbContext : DbContext
    {
        public DpizzadbContext()
        {
        }

        public DpizzadbContext(DbContextOptions<DpizzadbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orderdatatale> Orderdatatales { get; set; } = null!;
        public virtual DbSet<PizzaDataTb> PizzaDataTbs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DMQ8EIK\\SQLEXPRESS;Database=Dpizzadb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orderdatatale>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("PK__orderdat__080E3775F0179D82");

                entity.ToTable("orderdatatale");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(500)
                    .IsFixedLength();

                entity.Property(e => e.Customername)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Dateoforder)
                    .HasColumnType("datetime")
                    .HasColumnName("dateoforder");

                entity.Property(e => e.Pizzaid).HasColumnName("pizzaid");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Slices)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("slices");

                entity.Property(e => e.Toppins)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("toppins");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Orderdatatales)
                    .HasForeignKey(d => d.Pizzaid)
                    .HasConstraintName("FK__orderdata__pizza__5CD6CB2B");
            });

            modelBuilder.Entity<PizzaDataTb>(entity =>
            {
                entity.HasKey(e => e.PizzaId)
                    .HasName("PK__PizzaDat__0B6012DD2ACBC283");

                entity.ToTable("PizzaDataTb");

                entity.Property(e => e.PizzaId).ValueGeneratedNever();

                entity.Property(e => e.Discription)
                    .HasMaxLength(300)
                    .HasColumnName("discription")
                    .IsFixedLength();

                entity.Property(e => e.Img)
                    .HasMaxLength(855)
                    .HasColumnName("img")
                    .IsFixedLength();

                entity.Property(e => e.NumberOfSlice)
                    .HasMaxLength(40)
                    .HasColumnName("Number_of_slice")
                    .IsFixedLength();

                entity.Property(e => e.PizzCrust)
                    .HasMaxLength(800)
                    .IsFixedLength();

                entity.Property(e => e.PizzaName)
                    .HasMaxLength(800)
                    .IsFixedLength();

                entity.Property(e => e.PizzaPrice)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Pizza_price");

                entity.Property(e => e.PizzaType)
                    .HasMaxLength(800)
                    .HasColumnName("Pizza_type")
                    .IsFixedLength();

                entity.Property(e => e.VegNon)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("veg_non")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
