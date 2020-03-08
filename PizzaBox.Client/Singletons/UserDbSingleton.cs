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
  }
}