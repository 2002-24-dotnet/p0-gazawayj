using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client.Singleton
{
  public class OrderSingleton
  {
    private static readonly OrderRepository _or = new OrderRepository();
    private static readonly OrderSingleton _os = new OrderSingleton();

    public static OrderSingleton Instance
    {
      get
      {
        return _os;
      }
    }
    public bool CreateOrder(Order order)
    {
      return _or.Create(order);
    }
    public List<Order> GetOrdersForStore(long StoreId)
    {
      return _or.GetAllOrders().Where(o => o.StoreId == StoreId).ToList();
    }
    public List<Order> GetOrdersForCustomer(long CustomerId)
    {
      return _or.GetAllOrders().Where(o => o.CustomerId == CustomerId).ToList();
    }
  }
}