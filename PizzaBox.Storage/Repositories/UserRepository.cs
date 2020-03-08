using PizzaBox.Storage.Databases;

namespace PizzaBox.Storage.Repositories
{
  public class UserRepository
  {
    private static readonly PizzaBoxDbContext _db = PizzaBoxDbContext.Instance;
  }
}