using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singleton;

namespace PizzaBox.Client.Controllers
{
  public class StoreController
  {
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
  }
}