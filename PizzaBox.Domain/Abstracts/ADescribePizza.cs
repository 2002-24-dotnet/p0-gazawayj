using System;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class ADescribePizza
  {
    public string Name { get; set; }
    public long Id { get; set; }
    public virtual decimal Price { get; set; }
    public ADescribePizza()
    {
      Id = DateTime.Now.Ticks;
    }
  }
}
