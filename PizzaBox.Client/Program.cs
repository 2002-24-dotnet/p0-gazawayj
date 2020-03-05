using PizzaBox.Domain.Singleton;
using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client
{
  internal class Program
  {
    private static PizzariaSingleton _pr = new PizzariaSingleton();
    private static void Main(string[] args)
    {
      //TODO: Ask for log in type
      //TODO: Ask for user name and password
      //TODO: Create connection to storage
      //TODO: Log in using given info
      //TODO: Display options based on login type
      //TODO: Interact with storage to satisfy business logic
      GetAllPizzas();
    }

    private static void GetAllPizzas()
    {
      
      foreach (var p in _pr.Get())
      {
        System.Console.WriteLine(p);
      }
    }
  }
}
