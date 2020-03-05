using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Topping : ADescribePizza
  {
    public long ToppingId { get; set; }
    private string _toppingName;
    public string ToppingName
    {
        get { return _toppingName; }
        set { _toppingName = value; }
    }
    private decimal _price;
    public decimal Prices
    {
        get { return _price; }
        set { _price = value; }
    }
    public Topping()
    {
      ToppingId = DateTime.Now.Ticks;
    }
  }
}