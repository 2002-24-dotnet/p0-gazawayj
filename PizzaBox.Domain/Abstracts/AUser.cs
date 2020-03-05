using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

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
    private string _login;
    public string Login
    {
        get { return _login; }
        set { _login = value; }
    }
    
    public abstract Dictionary<int, Order> GetOrders();
  }
}