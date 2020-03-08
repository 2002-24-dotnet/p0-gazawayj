namespace PizzaBox.Domain.Models
{
  public class OrderPizza
  {
    public long Id { get; set; }
    public long PizzaId { get; set; }
    public Order Order { get; set; }
    public Pizza Pizza { get; set; }
  }
}