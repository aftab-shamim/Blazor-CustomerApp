using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CityBank.Models.Domain;

namespace CityBank.Data
{
    public partial class CityBankDbContext : DbContext
    {
        public CityBankDbContext()
        {
        }

        public CityBankDbContext(DbContextOptions<CityBankDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountsInfo> AccountsInfo { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-ACBGSG3D;Database=CityBankDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountsInfo>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("PK__Accounts__BE2ACD6EDA9AC85A");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.TotalBalance).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AccountsInfo)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__AccountsI__Custo__2B3F6F97");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
