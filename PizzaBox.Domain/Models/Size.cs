using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Size : ADescribePizza
  {
    public List<Pizza> Pizzas { get; set; }
    public Size()
    {
      Id = DateTime.Now.Ticks;
      Pizzas = new List<Pizza>();
    }
  }
}