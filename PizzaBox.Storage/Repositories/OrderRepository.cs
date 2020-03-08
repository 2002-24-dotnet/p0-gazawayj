using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories
{
  public class OrderRepository
  {
    private static readonly PizzaBoxDbContext _db = PizzaBoxDbContext.Instance;

    public bool Create(Order order)
    {
      _db.Order.Add(order);
      return _db.SaveChanges() == 1;
    }

    public List<Order> GetAllOrders()
    {
      return _db.Order.ToList();
    }
  }
}