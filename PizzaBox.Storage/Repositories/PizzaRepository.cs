using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storage.Repositories
{
  public class PizzaRepository
  {
    public List<Pizza> Get()
    {
      return new List<Pizza>()
      {
        new Pizza()
      };
    }
  }
}