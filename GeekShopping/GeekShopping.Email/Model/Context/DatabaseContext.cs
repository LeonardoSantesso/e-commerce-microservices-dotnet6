using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Email.Model.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<EmailLog> Emails { get; set; }
    }
}
