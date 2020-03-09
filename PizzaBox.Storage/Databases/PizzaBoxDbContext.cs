using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Databases
{
  public class PizzaBoxDbContext : DbContext
  {

    //Create a singleton of PizzaBoxDbContext so different entities don't
    //conflict with eachother by having different contexts
    private static readonly PizzaBoxDbContext _pbc = new PizzaBoxDbContext();

    public static PizzaBoxDbContext Instance 
    {
      get
      {
        return _pbc;
      }
    }
    
    public DbSet<Pizza> Pizza { get; set; }
    public DbSet<Size> Size { get; set; }
    public DbSet<Topping> Topping { get; set; }
    public DbSet<Crust> Crust { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Store> Store { get; set; }


    //TODO: add user, order, and store

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Password12345");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Crust>().HasKey(c => c.Id);
      builder.Entity<Size>().HasKey(s => s.Id);
      builder.Entity<Topping>().HasKey(t => t.Id);
      builder.Entity<PizzaTopping>().HasKey(pt => new { pt.PizzaId, pt.Id });
      builder.Entity<OrderPizza>().HasKey(po => new { po.PizzaId, po.Id });
      //define primary key of entity type (table) pizza
      builder.Entity<Pizza>().HasKey(p => p.Id);
      //TODO: Complete the connections for below entities
      builder.Entity<User>().HasKey(u => u.Id);
      builder.Entity<Order>().HasKey(o => o.OrderId);
      builder.Entity<Store>().HasKey(s => s.StoreId);


      //One crust can be on many pizzas, but each pizza can only have one crust
      builder.Entity<Crust>().HasMany(c => c.Pizzas).WithOne(p => p.Crust);
      builder.Entity<Pizza>().HasMany(p => p.Toppings).WithOne(pt => pt.Pizza).HasForeignKey(pt => pt.PizzaId);
      builder.Entity<Size>().HasMany(s => s.Pizzas).WithOne(p => p.Size);
      builder.Entity<Topping>().HasMany(t => t.PizzaToppings).WithOne(pt => pt.Topping).HasForeignKey(pt => pt.Id);
      //builder.Entity<Order>().HasMany(p => p.Pizzas).WithOne(o => o.Order).HasForeignKey(p => p.Id);

      builder.Entity<Store>().HasData(new Store[]
      {
        new Store() { StoreName = "Jim's Pizza #1", Address = "501 Main St, Fake_City, Fake_State, 90210", Phone = "1900pizzapls" },
        new Store() { StoreName = "Jim's Pizza #32", Address = "2435 W 57th Ave, Fake_City, Fake_State, 90210", Phone = "1900pizzanow" }
      });
      //Defines all the crust
      builder.Entity<Crust>().HasData(new Crust[]
      {
        new Crust() { Name = "Thin Crust", Price = 2.00M },
        new Crust() { Name = "New York Style", Price = 3.00M },
        new Crust() { Name = "Deep Dish", Price = 4.00M }
      });

      //Defines the Sizes
      builder.Entity<Size>().HasData(new Size[]
      {
        new Size() { Name = "Small", Price = 10.00M },
        new Size() { Name = "Medium", Price = 12.00M },
        new Size() { Name = "Large", Price = 14.00M }
      });

      //Defines the Toppings
      builder.Entity<Topping>().HasData(new Topping[]
      {
        new Topping() { Name = "Cheese", Price = .25M},
        new Topping() { Name = "Pepperoni", Price = .75M},
        new Topping() { Name = "Sauce", Price = .55M},
      });
    }
  }
}