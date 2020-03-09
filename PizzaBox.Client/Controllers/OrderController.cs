using System;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singleton;

namespace PizzaBox.Client.Controllers
{
  public class OrderController
  {
    private static readonly PizzariaSingleton _ps = PizzariaSingleton.Instance;
    internal void CreateOrder(Order newOrder)
    {
      _ps.CreateOrder(newOrder);
    }

    internal void CreatePizza(Pizza userPizza)
    {
      _ps.CreatePizza(userPizza);
    }
  }
}