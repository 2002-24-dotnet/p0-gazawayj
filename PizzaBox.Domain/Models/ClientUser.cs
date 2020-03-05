using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class ClientUser : AUser
  {
    //TODO: Complete timestamp checking
    public override Dictionary<int, Order> GetOrders()
    {
      //TODO: Add call to DB
      return new Dictionary<int, Order>();
    }
    public void PlaceOrder(Order order)
    {
      //TODO: implement
    }
  }
}