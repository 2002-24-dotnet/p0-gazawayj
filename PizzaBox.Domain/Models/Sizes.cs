namespace PizzaBox.Domain.Models
{
  public class Sizes
  {
    private Size _pizzaSize;
    public Size PizzaSize
    {
        get { return _pizzaSize; }
        set { _pizzaSize = value; }
    }
  }

  public enum Size
  {
      Small,
      Medium,
      Large
  }
}