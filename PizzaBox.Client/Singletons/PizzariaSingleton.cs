using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client.Singleton
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


    private static readonly OrderRepository _or = new OrderRepository();
    private static readonly GenericRepository<Crust> _cr = new GenericRepository<Crust>();
    private static readonly GenericRepository<Topping> _tr = new GenericRepository<Topping>();
    private static readonly GenericRepository<Size> _sr = new GenericRepository<Size>();

    //CREATE of CRUD
    public bool CreatePizza(Crust crust, Size size, List<PizzaTopping> toppings)
    {
      var p = new Pizza()
      {
        Crust = crust,
        Size = size,
        Toppings = toppings
      };
      return _pr.Create(p);
    }
    internal bool CreatePizza(Pizza userPizza)
    {
      return _pr.Create(userPizza);
    }
    //READ of CRUD
    public List<Pizza> GetAllPizzasForUser(long userId)
    {
      return _pr.GetAllPizzas().Where(p => p.UserId == userId).ToList();
    }

    internal List<Size> GetAllSizes()
    {
      return _sr.ReadAll().ToList();
    }

    internal List<Crust> GetAllCrusts()
    {
      return _cr.ReadAll().ToList();
    }

    public List<Pizza> GetAllPizzas()
    {
      return _pr.GetAllPizzas().ToList();
    }

    public List<Topping> GetAllToppings()
    {
      return _tr.ReadAll().ToList();
    }
    internal void CreateOrder(Order newOrder)
    {
      _or.Create(newOrder);
    }
        internal void DeleteOrder(Order newOrder)
    {
      _or.Delete(newOrder);
    }
  }
}