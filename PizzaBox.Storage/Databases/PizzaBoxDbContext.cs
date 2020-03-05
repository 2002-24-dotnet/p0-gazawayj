using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Databases
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<Pizza> Pizzas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Password12345");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      //define primary key of entity type (table) pizza
      builder.Entity<Pizza>().HasKey(p => p.PizzaID);
      //add new pizzas
      builder.Entity<Pizza>().HasData(new Pizza[]
      {
        new Pizza()
        {
          PizzaID = 1
        }
      });
    }
  }
}