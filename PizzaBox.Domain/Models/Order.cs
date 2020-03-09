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
    private string _orderDateTime;
    public string OrderDateTime
    {
        get { return _orderDateTime; }
        set { _orderDateTime = value; }
    }
    
    private long _storeId;
    public long StoreId
    {
        get { return _storeId; }
        set { _storeId = value; }
    }
    
    private long _orderId;
    public long OrderId
    {
        get { return _orderId; }
        set { _orderId = value; }
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
    public override string ToString()
    {
      return OrderDateTime + " " + PizzasString();
    }

    private string PizzasString()
    {
      string temp = "";
      foreach(Pizza p in Pizzas)
      {
        temp += '\t' + (p + Environment.NewLine);
      }
      return temp;
    }

    public Order()
    {
      //Id = DateTime.Now.Ticks;
    }
  }
}