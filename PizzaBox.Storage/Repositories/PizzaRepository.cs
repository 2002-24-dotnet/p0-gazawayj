using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;
using System.Linq;

namespace PizzaBox.Storage.Repositories
{
  public class PizzaRepository
  {
    private static readonly PizzaBoxDbContext _db = new PizzaBoxDbContext();
    public List<Pizza> Get()
    {
      return _db.Pizzas.ToList();
    }
  }
}