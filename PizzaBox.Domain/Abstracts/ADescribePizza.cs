using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class ADescribePizza
  {
    public string Name { get; set; }
    public decimal Price { get; set; }
    #region NAVIGATIONAL PROPERTIES
    //public virtual long PizzaId { get; set; }
    //public virtual Pizza Pizza { get; set; }
    #endregion
  }
}
