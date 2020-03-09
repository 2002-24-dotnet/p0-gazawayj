﻿using PizzaBox.Domain.Controller;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singleton;

namespace PizzaBox.Client
{
  internal class Program
  {
    private static readonly PizzariaSingleton _pr = PizzariaSingleton.Instance;
    private static UserController _uc = new UserController();
    private static void Main(string[] args)
    {
      System.Console.WriteLine("Type in your username please:");
      string user = System.Console.ReadLine();
      System.Console.WriteLine("Type in your password please:");
      string pass = System.Console.ReadLine();
      User currentUser = _uc.LogIn(user, pass);
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
