using System;
using PizzaBox.Domain.Singleton;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client
{
  internal class Program
  {
    private static readonly PizzariaSingleton _pr = PizzariaSingleton.Instance;
    private static void Main(string[] args)
    {
      //TODO: Ask for log in type
      //TODO: Ask for user name and password
      //TODO: Create connection to storage
      //TODO: Log in using given info
      //TODO: Display options based on login type
      //TODO: Interact with storage to satisfy business logic
      GetAllPizzas();
      GetAllToppings();
      GetAllSizes();
      GetAllCrusts();
    }

    private static void PostPizza()
    {
      //_pr.Post()
    }

    private static void GetAllToppings()
    {
      foreach (var t in _pr.GetAllToppings())
      {
        System.Console.WriteLine(t.Name);
      }
    }

    private static void GetAllSizes()
    {
      foreach (var s in _pr.GetAllSizes())
      {
        System.Console.WriteLine(s.Name);
      }
    }

    private static void GetAllCrusts()
    {
      foreach (var c in _pr.GetAllCrusts())
      {
        System.Console.WriteLine(c.Name);
      }
    }

    private static void GetAllPizzas()
    {
      
      foreach (var p in _pr.GetAllPizzas())
      {
        System.Console.WriteLine(p);
      }
    }
  }
}
