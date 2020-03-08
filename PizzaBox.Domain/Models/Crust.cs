using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Crust : ADescribePizza
  { 
    public List<Pizza> Pizzas { get; set; }
  }
}