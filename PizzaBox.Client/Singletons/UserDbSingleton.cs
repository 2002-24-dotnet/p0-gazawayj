using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client.Singleton
{
  public class UserDbSingleton
  {
    private static readonly UserDbSingleton _udb = new UserDbSingleton();
    private static readonly UserRepository _ur = new UserRepository();

    public static UserDbSingleton Instance 
    {
      get
      {
        return _udb;
      }
    }
    private UserDbSingleton()
    {
    }

    public bool Create(User user)
    {
      return _ur.Create(user);
    }
    public List<User> GetAllClientUsersForStore(long StoreId)
    {
      return _ur.ReadAllClientsForStore(StoreId);
    }
    public User CheckLoginInfo(string userName, string pass)
    {
      var temp = _ur.FindUser(userName);
      if (temp != null && temp.Login == userName && temp.Password == pass)
      {
        return temp;
      }
      return null;
    }

    public List<Store> GetStores()
    {
      return _ur.GetStores();
    }

    public List<Order> GetUserOrderHistory(long userId)
    {
      return _ur.GetUserOrderHistory(userId);
    }

    public User GetUser(long Id)
    {
      return _ur.ReadUser(Id);
    }

    public Store GetStore(long id)
    {
      return _ur.FindStore(id);
    }

    internal List<Order> GetStoreOrderHistory(long id)
    {
      return _ur.GetAllOrdersForStore(id);
    }

    internal string GetStoreSales(long id)
    {
      decimal totalSales = 0.00M;
      int numLarge = 0;
      int numMed = 0;
      int numSmall = 0;
      foreach(Order o in GetStoreOrderHistory(id))
      {
        totalSales += o.Price;
        foreach(Pizza p in o.Pizzas)
        {
          if (p.Size.Name == "Small") {numSmall++;}
          if (p.Size.Name == "Medium") {numMed++;}
          else {numLarge++;}
        }
      }
      return "Pizzas sold: " + numLarge + " Large, " + numMed + " Medium, " + numSmall + " Small. Total sales: " + totalSales;
    }

    internal bool CreateUserLogin(string userName, string password, string fullName, string address, string phone)
    {
      User newUser = new User()
      {
        Login = userName, Password = password, Name = fullName, Phone = phone, Address = address, IsStore = false
      };
      return _ur.Create(newUser);
    }
  }
}