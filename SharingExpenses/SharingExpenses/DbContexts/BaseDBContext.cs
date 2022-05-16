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
            modelBuilder.Entity<Expenses>()
                .HasOne(x => x.Owner)
                .WithMany()
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Groups>()
                .HasMany(x => x.Users);

            modelBuilder.Entity<Groups>()
                .HasMany(x => x.Payments);

            modelBuilder.Entity<Groups>()
                .HasMany(x => x.Expenses);


            modelBuilder.Entity<Payments>()
                .HasOne(x => x.FromUser)
                .WithMany()
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Payments>()
                .HasOne(x => x.ToUser)
                .WithMany()
                .IsRequired(true)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Users>();


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
