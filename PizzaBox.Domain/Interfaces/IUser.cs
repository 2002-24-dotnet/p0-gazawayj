using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Interfaces
{
  public interface IUser
  {
    Dictionary<int, Order> GetOrders();
  }
}