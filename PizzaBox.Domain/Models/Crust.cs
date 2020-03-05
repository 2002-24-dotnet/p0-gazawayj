using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
  public class Crust : ADescribePizza
  {
    private string _crustType;
    public string CrustType
    {
        get { return _crustType; }
        set { _crustType = value; }
    }    
    public long CrustId { get; set; }

    public Crust()
    {
      CrustId = DateTime.Now.Ticks;
    }
  }
}