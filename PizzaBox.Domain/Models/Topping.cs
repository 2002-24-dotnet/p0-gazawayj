using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Topping : ADescribePizza
  {
    public List<PizzaTopping> PizzaToppings { get; set; }
  }
}