using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Pizza 
  {
    
    #region NAVIGATIONAL PROPERTIES
    public Order Order { get; set; }
    private Crust _crust;
    public Crust Crust
    {
        get { return _crust; }
        set { _crust = value; }
    }
    private Size _size;
    public Size Size
    {
        get { return _size; }
        set { _size = value; }
    }
    private List<PizzaTopping> _toppings;
    public long UserId;

    public List<PizzaTopping> Toppings
    {
        get { return _toppings; }
        set { _toppings = value; }
    }
    #endregion
        public long Id { get; set; }
        public decimal Price
    {
      get
      {
        if ( Crust == null || Toppings == null || Size == null )
        {
          return 0;
        }
        return Crust.Price + Size.Price + (Toppings.Sum( t => t.Topping.Price));
      }
    }

    public override string ToString()
    {
      return $"{Price} {Crust.Name ?? "N/A"} {Size.Name ?? "N/A"}" + GetToppings();
    }

    private string GetToppings()
    {
      string temp = ": Toppings: ";
      foreach (PizzaTopping pt in this.Toppings)
      {
        temp += pt.Topping.Name + " ";
      }
      return temp;
    }

    public Pizza()
    {
      Id = DateTime.Now.Ticks;
    }
  }
}