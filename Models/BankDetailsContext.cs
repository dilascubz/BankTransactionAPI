using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EvaluationTest.Models
{
    public partial class BankDetailsContext : DbContext
    {
        public BankDetailsContext()
        {
        }

        public BankDetailsContext(DbContextOptions<BankDetailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankAccount> BankAccounts { get; set; } = null!;
        public virtual DbSet<BankTransaction> BankTransactions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("" +
                    "Server=;Database=BankDetails; " +
                    "User Id=;Password=; " +
                    "Trusted_Connection=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.ToTable("BankAccount");

                entity.Property(e => e.AccId).HasMaxLength(20);

                entity.Property(e => e.BankAmount).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<BankTransaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedDateTime).HasColumnType("datetime");

                entity.Property(e => e.TransferAmount).HasColumnType("decimal(18, 4)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
