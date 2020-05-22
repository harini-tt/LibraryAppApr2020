using System;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp
{
    public class LibraryContext : DbContext
    {
        public DbSet<MemberAcc> accounts { get; set; }
        public DbSet<Bookrecipt> transactions { get; set; }
        // overriden method: change parents behavior
        public LibraryContext()
        {

        }
        public LibraryContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=master;Integrated Security=True;Initial Catalog = LibraryApp;Connect Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberAcc>(entity =>
            {
                entity.ToTable("Accounts");
                entity.HasKey(a => a.AccountNumber);
                entity.Property(a => a.AccountNumber)
                    .ValueGeneratedOnAdd();
                entity.Property(a => a.MemberName)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(a => a.UserName)
                    .HasMaxLength(30);
                entity.Property(a => a.AccountType)
                    .IsRequired();
                entity.Property(a => a.PinNumber)
                    .IsRequired()
                    .HasMaxLength(10);
                entity.Property(a => a.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(a => a.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(11);
                
                
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
