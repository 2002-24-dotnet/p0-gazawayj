using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories
{
  public class UserRepository
  {
    private static readonly PizzaBoxDbContext _db = PizzaBoxDbContext.Instance;

    //CREATE of CRUD
    public bool Create(User user)
    {
      _db.User.Add(user);
      return _db.SaveChanges() == 1;
    }
    //READ of CRUD that returns all users of that store
    public List<User> ReadAllClientsForStore(long storeId)
    {
      return _db.User.ToList();
    }
    //READ of CRUD that returns a particular user of a store
    public User ReadUser(long Id)
    {
      return _db.User.SingleOrDefault(u => u.Id == Id);
    }
    //UPDATE of CRUD
    public bool UpdateUser(User user)
    {
      User temp = ReadUser(user.Id);
      temp = user;
      return _db.SaveChanges() == 1;
    }
    //DELETE of CRUD
    public bool DeleteUser(long id)
    {
      User temp = ReadUser(id);
      _db.Remove(temp);
      return _db.SaveChanges() == 1;
    }

    public User FindUser(string userName)
    {
      return _db.User.SingleOrDefault(u => u.Login == userName);
    }
    public List<Store> GetStores()
    {
      return _db.Store.ToList();
    }

    public Store FindStore(long id)
    {
      return _db.Store.SingleOrDefault(s => s.Id == id);
    }

    public List<Order> GetAllOrdersForStore(long id)
    {
      return _db.Order.Where(o => o.StoreId == id).ToList();
    }

    public List<Order> GetUserOrderHistory(long id)
    {
      return _db.Order.Where(o => o.CustomerId == id).ToList();
    }
  }
}