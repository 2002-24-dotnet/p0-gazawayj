using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Domain.Singleton
{
  public class PizzariaSingleton
  {
    private static readonly PizzariaSingleton _ps = new PizzariaSingleton();
    public PizzariaSingleton Instance
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
    public bool Post(Crust crust, Size size, List<Topping> toppings)
    {
      var p = new Pizza()
      {
        Crust = crust,
        Size = size,
        Toppings = toppings
      };
      return _pr.Post(p);
    }
    public List<Pizza> Get(string user)
    {
      //TODO: Look at Fred's code to get rest of implementation
      return _pr.Get().Where( p => p.Name == user).ToList();
    }
  }
}