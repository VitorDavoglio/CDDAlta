using Domain_CodigoPenal.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra_CodigoPenal.Repository
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<CriminalCode> CriminalCodes { get; set; }
        public DbSet<Status> Status { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
