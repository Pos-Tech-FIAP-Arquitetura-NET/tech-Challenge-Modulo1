using Microsoft.EntityFrameworkCore;
using Play_investe.Entity;
using StoreFIAP.Configurations;
using StoreFIAP.Entity;
using System.Transactions;

namespace StoreFIAP.Repository
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Bound> Bound { get; set; }
        public DbSet<Investment> Investment { get; set; }
        public DbSet<TransactionsBank> TransactionsBank { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetValue<string>("ConnectionStrings:ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }


    }
}
