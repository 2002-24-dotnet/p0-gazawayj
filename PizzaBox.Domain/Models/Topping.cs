namespace PizzaBox.Domain.Models
{
  public class Topping
  {
    private string _toppingName;
    public string ToppingName
    {
        get { return _toppingName; }
        set { _toppingName = value; }
    }
  }
}