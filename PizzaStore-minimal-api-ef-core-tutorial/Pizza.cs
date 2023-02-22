using Microsoft.EntityFrameworkCore;

namespace PizzaStore.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string ? Name { get; set; }
        public string? Description { get; set; }
    }

    // To set up in-memory database
    /**
        DbContext represents a connection or session,
        used to query and save instances of entities
        in a database
    */
    class PizzaDb : DbContext 
    {
        public PizzaDb(DbContextOptions options) : base(options) { }
        public DbSet<Pizza> Pizzas { get; set; } = null!; 
    }
}

