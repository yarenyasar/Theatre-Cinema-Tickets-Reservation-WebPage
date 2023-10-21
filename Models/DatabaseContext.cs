using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace WebApplication1.Models {
    public class DatabaseContext : DbContext {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {
        }

        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<ContactModel> Contacts { get; set; }
    }
}
