using System;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp
{
    class LibraryContext : DbContext
    {
        public DbSet<MemberAcc> accounts { get; set; }
        public DbSet<Bookrecipt> transactions { get; set; }
        // overriden method: change parents behavior
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = localhost; Initial Catalog=LibraryAppApr2020; User ID = sa; Password = reallyStrongPwd123; Connect Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberAcc>(entity =>
            {
                entity.ToTable("Accounts");
                entity.HasKey(a => a.AccountNumber);
                entity.Property(a => a.AccountNumber)
                    .ValueGeneratedOnAdd();
                entity.Property(a => a.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(a => a.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(11);
                entity.Property(a => a.UserName)
                    .HasMaxLength(30);
                entity.Property(a => a.MemberName)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(a => a.PinNumber)
                    .IsRequired()
                    .HasMaxLength(10);
            });
            modelBuilder.Entity<Bookrecipt>(entity =>
            {
                entity.ToTable("Transactions");
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id)
                    .ValueGeneratedOnAdd();
            });
        }
    }
}
