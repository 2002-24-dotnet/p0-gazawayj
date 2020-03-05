using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Databases
{
  public class PizzaBoxDbContext : DbContext
  {
    public DbSet<Pizza> Pizza { get; set; }
    public DbSet<Size> Size { get; set; }
    public DbSet<Topping> Topping { get; set; }
    public DbSet<Crust> Crust { get; set; }

    //TODO: add user, order, and store

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer("server=localhost;database=pizzaboxdb;user id=sa;password=Password12345");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Crust>().HasKey(c => c.CrustId);
      builder.Entity<Size>().HasKey(s => s.SizeId);
      builder.Entity<Topping>().HasKey(t => t.ToppingId);
      //define primary key of entity type (table) pizza
      builder.Entity<Pizza>().HasKey(p => p.PizzaId);

      builder.Entity<Crust>().HasMany<Pizza>().WithOne(p => p.Crust);
      builder.Entity<Size>().HasMany<Pizza>().WithOne(p => p.Size);
      //Need to update so that many pizzas can have the same crust, topping, etc
      builder.Entity<Topping>().HasMany<Pizza>();


      //Define each table type

      //Defines the pizza, uncomment for signature pizzas
      //builder.Entity<Pizza>().HasData(new Pizza());

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