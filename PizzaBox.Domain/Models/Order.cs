using System.Collections.Generic;
namespace PizzaBox.Domain.Models
{
  public class Order 
  {
    private int _userID;
    public int UserID
    {
        get { return _userID; }
        set { _userID = value; }
    }
    private int _storeID;
    public int Id
    {
        get { return _storeID; }
        set { _storeID = value; }
    }
    
    private int _orderID;
    public int OrderID
    {
        get { return _orderID; }
        set { _orderID = value; }
    }
    /// <summary>
    /// Get the pizzas from this order
    /// </summary>
    /// <returns>Container of ordered pizzas</returns>
    public Dictionary<int, Pizza> GetPizzas()
    {
      //TODO: implement
      return new Dictionary<int, Pizza>();
    }
    /// <summary>
    /// Computes the cost of this order
    /// </summary>
    /// <returns>double representing the order cost</returns>
    public double ComputeCost()
    {
      //TODO:
      return 0;
    }
    /// <summary>
    /// Checks if the order limit has been reached.abstract Run before adding another pizza
    /// </summary>
    /// <returns>A bool representing a state of being able to add to the order</returns>
    public bool CheckOrderLimit()
    {
      return (ComputeCost() <= 250.00);
    }
  }
}