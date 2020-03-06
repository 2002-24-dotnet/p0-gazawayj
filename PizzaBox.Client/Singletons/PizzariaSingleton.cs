using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Domain.Singleton
{
  public class PizzariaSingleton
  {
    private static readonly PizzariaSingleton _ps = new PizzariaSingleton();
    public static PizzariaSingleton Instance
    {
      get
      {
        return _ps;
      }
    }

    private PizzariaSingleton()
    {
    }

    private static readonly PizzaRepository _pr = new PizzaRepository();
    public bool Post(Crust crust, Size size, List<PizzaTopping> toppings)
    {
      var p = new Pizza()
      {
        Crust = crust,
        Size = size,
        Toppings = toppings
      };
      return _pr.Post(p);
    }
    public List<Pizza> Get(long userId)
    {
      //TODO: Look at Fred's code to get rest of implementation
      return _pr.Get().Where( p => p.userId == userId).ToList();
    }
        public List<Pizza> Get()
    {
      //TODO: Look at Fred's code to get rest of implementation
      return _pr.Get().ToList();
    }
  }
}