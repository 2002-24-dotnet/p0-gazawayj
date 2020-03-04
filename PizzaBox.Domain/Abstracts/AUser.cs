using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Abstracts
{
  public abstract class AUser : IUser
  {
    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    private int _phone;
    public int Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }
  }
}