using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories
{
  public class GenericRepository<T> where T: ADescribePizza
  {
    private static readonly PizzaBoxDbContext _db = PizzaBoxDbContext.Instance;
    //CREATE of CRUD
    public bool Create(T part)
    {
      _db.Set<T>().Add(part);
      return _db.SaveChanges() == 1;
    }
    //READ of CRUD
    public List<T> ReadAll()
    {
      return _db.Set<T>().ToList();
    }
    //READ(all) of CRUD
    public T Read(long Id)
    {
      return _db.Set<T>().SingleOrDefault( i => i.Id == Id);
    }
    //UPDATE of CRUD
    public bool Update(T updated)
    {
      T temp = Read(updated.Id);
      temp = updated;
      return _db.SaveChanges() == 1;
    }
    //DELETE of CRUD
    public bool Delete(long Id)
    {
      T temp = Read(Id);
      _db.Remove(temp);
      return _db.SaveChanges() == 1;
    }
  }
}