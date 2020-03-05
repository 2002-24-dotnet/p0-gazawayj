using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PizzaBox.Storage.Repositories
{
  public class PizzaRepository
  {
    private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();
    public List<Pizza> Get()
    {
      //Use Eager loading, loads main object and dependencies
      return _db.Pizza.Include(p => p.Crust).Include(p => p.Size).Include(p => p.Toppings).ToList();
    }
    public Pizza Get(long id)
    {
      return _db.Pizza.SingleOrDefault(p => p.PizzaId == id);
    }

    /// <summary>
    /// Adds a pizza to the repository
    /// </summary>
    /// <param name="pizza">The pizza to be loaded</param>
    /// <returns>Boolean; true if added</returns>
    public bool Post(Pizza pizza)
    {
      _db.Pizza.Add(pizza);
      return _db.SaveChanges() == 1;
    }

    public bool Put(Pizza pizza)
    {
      //find a pointer to the pizza in DB
      Pizza p = Get(pizza.PizzaId);
      //save the changes in DB
      p = pizza;
      // _db.Update(Get(pizza.PizzaId));
      return _db.SaveChanges() == 1;
    }
  }
}