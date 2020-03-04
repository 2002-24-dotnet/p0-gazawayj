using PizzaBox.Storage.Repositories;

namespace PizzaBox.Client
{
  internal class Program
  {
    private static PizzaRepository _pr = new PizzaRepository();
    private static void Main(string[] args)
    {
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
