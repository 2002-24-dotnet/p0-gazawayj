using System;
using System.Collections.Generic;
using PizzaBox.Client.Singleton;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
  public class StoreController
  {
    private static readonly UserDbSingleton _us = UserDbSingleton.Instance;
    private static readonly PizzariaSingleton _ps = PizzariaSingleton.Instance;
    internal List<Size> GetAvailableSizes()
    {
      return _ps.GetAllSizes();
    }

    internal List<Crust> GetAvailableCrusts()
    {
      return _ps.GetAllCrusts();
    }

    internal List<Topping> GetAvailableToppings()
    {
      return _ps.GetAllToppings();
    }

    internal List<Order> GetFullOrderHistory(long userId)
    {
      return _us.GetStoreOrderHistory(userId);
    }

    internal List<User> GetAllCustomersForStore(long id)
    {
      return _us.GetAllClientUsersForStore(id);
    }

    internal Store GetStore(string address)
    {
      return _us.GetStore(address);
    }
  }
}