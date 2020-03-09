using System;
using System.Collections.Generic;
namespace PizzaBox.Domain.Models
{
  public class Order 
  {
    private long _customerId;
    public long CustomerId
    {
        get { return _customerId; }
        set { _customerId = value; }
    }
    private int _storeId;
    public int StoreId
    {
        get { return _storeId; }
        set { _storeId = value; }
    }
    
    private long _Id;
    public long Id
    {
        get { return _Id; }
        set { _Id = value; }
    }
    private List<Pizza> _pizzas;
    public List<Pizza> Pizzas
    {
        get { return _pizzas; }
        set { _pizzas = value; }
    }

    public decimal Price { 
      get
      {
        decimal sum = 0.00M;
        foreach (Pizza p in Pizzas)
        {
          sum += p.Price;
        }
        return sum;
      }
    }
    public Order()
    {
      Id = DateTime.Now.Ticks;
    }
  }
}