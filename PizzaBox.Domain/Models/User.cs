using System;

namespace PizzaBox.Domain.Models
{
  public class User
  {
    private long _id;
    public long Id
    {
        get { return _id; }
        set { _id = value; }
    }
    
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
    private string _password;
    public string Password
    {
        get { return _password; }
        set { _password = value; }
    }
    public User()
    {
      Id = DateTime.Now.Ticks;
    }
  }
}