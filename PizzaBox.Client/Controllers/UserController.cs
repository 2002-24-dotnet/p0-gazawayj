using System;
using System.Collections.Generic;
using PizzaBox.Client.Singleton;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
  public class UserController
  {
    private static readonly UserDbSingleton _pr = UserDbSingleton.Instance;

    private User _curUser;
    public User CurUser
    {
        get { return _curUser; }
        set { _curUser = value; }
    }
    private Store _userStore;
    public Store UserStore
    {
        get { return _userStore; }
        set { _userStore = value; }
    }
    
    
    /// <summary>
    /// attempt to log a user into the DB using the supplied username and password
    /// </summary>
    /// <param name="user">Username</param>
    /// <param name="pass">Password</param>
    /// <returns>An instance of the user if found, else null</returns>
    public User LogIn(string user, string pass)
    {
      CurUser = _pr.CheckLoginInfo(user, pass);
      return CurUser;
    }

    public List<Order> ViewCustOrderHistory(long userId)
    {
      return _pr.GetUserOrderHistory(userId);
    }

    public List<Store> ViewStores()
    {
      return _pr.GetStores();
    }

    public void SetStore(long id)
    {
      UserStore = _pr.GetStore(id);
    }

    public List<Order> ViewStoreOrderHistory(long id)
    {
      return _pr.GetStoreOrderHistory(id);
    }

    public string GetStoreSales(long id)
    {
      return _pr.GetStoreSales(id);
    }

    internal bool CreateUserAccount(string userName, string password, string fullName, string address, string phone)
    {
      return _pr.CreateUserLogin(userName, password, fullName, address, phone);
    }
  }
}