using Microsoft.EntityFrameworkCore;
using SharingExpenses.Models.DbModels;

namespace SharingExpenses.DbContexts
{
    public class BaseDBContext : DbContext
    {
        public BaseDBContext(DbContextOptions<BaseDBContext> options) : base(options)
        {
        }

        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payments>()
            .HasKey(x => x.Id);

            modelBuilder.Entity<Payments>()
                 .HasOne(x => x.ToUser)
                 .WithMany(x => x.PaymentsTo)
                 .HasForeignKey(x => x.ToUserId)
                 .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Expenses>()
           .HasKey(x => x.Id);

            modelBuilder.Entity<Expenses>()
                .HasOne(x => x.Owner)
                .WithMany()
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Expenses>()
                .HasOne(x => x.Group)
                .WithMany()
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Groups>()
           .HasKey(x => x.Id);

            modelBuilder.Entity<Groups>()
                .HasMany(x => x.Users)
                .WithMany(x => x.Groups);

            modelBuilder.Entity<Groups>()
                .HasMany(x => x.Expenses)
                .WithOne(x => x.Group);

            modelBuilder.Entity<Groups>()
                .HasMany(x => x.Payments)
                .WithOne(x => x.Group);

            modelBuilder.Entity<Users>()
                .HasKey(x => x.Id);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json")
             .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));


        }
    }
}
