
using Microsoft.EntityFrameworkCore;

namespace JesusAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string ? FirstName { get; set; }
        public string ? LastName { get; set; }
    }

    class JesusApiDb : DbContext
    {
        public JesusApiDb(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; } = null!;
    }
}

