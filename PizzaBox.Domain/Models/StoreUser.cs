using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class StoreUser : AUser
  {
    /// <summary>
    /// Get all orders completed by the store
    /// </summary>
    /// <returns>Dictionary containing all orders</returns>
    public override Dictionary<int, Order> GetOrders()
    {
      //TODO: Make call to DB
      return new Dictionary<int, Order>();
    }
    
    /// <summary>
    /// Get all orders completed by a given customer
    /// </summary>
    /// <param name="user">Customer whose orders are to be returned</param>
    /// <returns>That customer's orders</returns>
    public Dictionary<int, Order> GetOrders(ClientUser user)
    {
      //TODO: Make call to DB
      return new Dictionary<int, Order>();
    }

    /// <summary>
    /// Compute total sales done by store
    /// </summary>
    /// <returns>Double representing total sales</returns>
    public double GetSales()
    {
      //TODO: Compute sales
      return 0;
    }
  }
}