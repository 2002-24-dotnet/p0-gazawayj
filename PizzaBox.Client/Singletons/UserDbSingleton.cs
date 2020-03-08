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
    public bool CheckLoginInfo(long id, string userName, string pass)
    {
      var temp = _ur.ReadUser(id);
      return (temp.Login == userName && temp.Password == pass);
    }
    public User GetUser(long Id)
    {
      return _ur.ReadUser(Id);
    }
    
  }
}