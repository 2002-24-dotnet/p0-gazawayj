using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Size : ADescribePizza
  {
    private string _pizzaSize;
    public string PizzaSize
    {
        get { return _pizzaSize; }
        set { _pizzaSize = value; }
    }
    public List<Pizza> Pizzas { get; set; }

    public long SizeId { get; set; }

    public Size()
    {
      SizeId = DateTime.Now.Ticks;
    }
    
  }
}