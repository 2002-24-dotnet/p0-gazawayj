using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Storage.Repositories
{
  public class PizzaRepository : GenericRepository<ADescribePizza>
  {
    public List<Pizza> GetAllPizzas()
    {
      //Use Eager loading, loads main object and dependencies
      return PizzaBoxDbContext.Instance.Pizza.Include(p => p.Crust).Include(p => p.Size).Include(p => p.Toppings).ToList();
    }
    public bool Create(Pizza pizza)
    {
      PizzaBoxDbContext.Instance.Pizza.Add(pizza);
      return PizzaBoxDbContext.Instance.SaveChanges() == 1;
    }
  }
}