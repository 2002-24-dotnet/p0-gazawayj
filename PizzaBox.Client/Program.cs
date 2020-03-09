using System.Linq;
using System;
using System.Collections.Generic;
using PizzaBox.Client.Controllers;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Singleton;

namespace PizzaBox.Client
{
  internal class Program
  {
    //private static readonly PizzariaSingleton _pr = PizzariaSingleton.Instance;
    private static UserController _uc = new UserController();
    private static OrderController _oc = new OrderController();
    private static StoreController _sc = new StoreController();
    private static User _user;
    private static Store _store;
    private static Order _newOrder;

    private static void Main(string[] args)
    {
      bool loggedIn = false;
      while (!loggedIn)
      {
        System.Console.WriteLine("Please select an option:");
        System.Console.WriteLine("1. Log in." + Environment.NewLine + "2. Create User.");
        int selection = Int32.Parse(System.Console.ReadLine());
        if (selection == 1) { loggedIn = DoLoginRoutine(); }
        if (selection == 2) { CreateUser(); }
        else { System.Console.WriteLine("Sorry, I didn't understand that."); }
      }
      bool stillUsing = true;
      while (stillUsing)
      {
        System.Console.WriteLine("Please select an option:" + Environment.NewLine + "1. Create an order.");
        System.Console.WriteLine("2. See available stores." + Environment.NewLine + "3. See order history.");
        System.Console.WriteLine("4. Quit.");
        int selection = Int32.Parse(System.Console.ReadLine());
        if (selection == 1) { CreateOrder(); }
      }

      //TODO: Ask for log in type
      //TODO: Ask for user name and password
      //TODO: Create connection to storage
      //TODO: Log in using given info
      //TODO: Display options based on login type
      //TODO: Interact with storage to satisfy business logic

    }

    private static void CreateOrder()
    {
      System.Console.WriteLine("Creating new order.");
      long storeID = GetStoreSelection();
      List<Pizza> pizzas = GetPizzaSelections();
    }

    private static List<Pizza> GetPizzaSelections()
    {
      bool creatingMore = true;
      while (creatingMore)
      {
        System.Console.WriteLine("Let's create a pizza!" + Environment.NewLine + "What size pizza would you like?");
        List<Size> sizes = _sc.GetAvailableSizes();
        int counter = 1;
        foreach (Size s in sizes)
        {
          System.Console.WriteLine(counter + ". " + s.Name);
          counter++;
        }
        int selection = Int32.Parse(System.Console.ReadLine());
        Size selectedSize = sizes.ElementAt(selection);
        counter = 1;
        System.Console.WriteLine("What type of crust would you like?");
        List<Crust> crusts = _sc.GetAvailableCrusts();
        foreach (Crust c in crusts)
        {
          System.Console.WriteLine(counter + ". " + c.Name);
          counter++;
        }
        selection = Int32.Parse(System.Console.ReadLine());
        Crust selectedCrust = crusts.ElementAt(selection);
        counter = 1;
        bool choosingToppings = true;
        List<Topping> availableToppings = _sc.GetAvailableToppings();
        List<Topping> selectedToppings = new List<Topping>();
        while (choosingToppings)
        {
          System.Console.WriteLine("What topping would you like to add?");
          System.Console.WriteLine("0. No more toppings.");
          foreach(Topping t in availableToppings)
          {
            System.Console.WriteLine(counter + ". " + t.Name);
            counter++;
          }
          selection = Int32.Parse(System.Console.ReadLine());
          if (selection == 0)
          {
            choosingToppings = false;
            System.Console.WriteLine("Adding pizza to order if valid");
          }
          else 
          {
            selectedToppings.Add(availableToppings.ElementAt(selection));
            availableToppings.Remove(availableToppings.ElementAt(selection));
          }
        }
        List<PizzaTopping> pizzaToppingList = new List<PizzaTopping>();
        foreach (Topping t in selectedToppings)
        {
          
        }
        Pizza userPizza = new Pizza() 
        {
          Crust = selectedCrust, Size = selectedSize, Toppings = new PizzaTopping() 
          {
            selectedToppings
          };
        };
      }
    }

    private static long GetStoreSelection()
    {
      System.Console.WriteLine("Please select which store you'd like to order from:");
      List<Store> stores = _uc.ViewStores();
      int counter = 1;
      foreach (Store s in stores)
      {
        System.Console.WriteLine(counter + ". " + s.StoreName + " " + s.Address);
        counter++;
      }
      int selection = Int32.Parse(System.Console.ReadLine());
      _uc.SetStore(stores.ElementAt(selection).Id);
      return stores.ElementAt(selection).Id;
    }

    private static void CreateUser()
    {
      bool goodNewUser = false;
      while (!goodNewUser)
      {
        System.Console.WriteLine("Please type in your desired username: ");
        string userName = System.Console.ReadLine();
        System.Console.WriteLine("Please type in your desire password:");
        string password = System.Console.ReadLine();
        System.Console.WriteLine("Please type in your full name:");
        string fullName = System.Console.ReadLine();
        System.Console.WriteLine("Please type in your address:");
        string address = System.Console.ReadLine();
        System.Console.WriteLine("Please type in your phone number:");
        string phone = System.Console.ReadLine();
        goodNewUser = _uc.CreateUserAccount(userName, password, fullName, address, phone);
        if (!goodNewUser) { System.Console.WriteLine("User info not unique, please try again."); }
        else { System.Console.WriteLine("Creating your account. You will be asked to log in."); }
      }
    }

    private static bool DoLoginRoutine()
    {
      System.Console.WriteLine("LOGIN:" + Environment.NewLine + "Please insert your username: ");
      string userName = System.Console.ReadLine();
      System.Console.WriteLine("Please insert your password:");
      string password = System.Console.ReadLine();
      _user = _uc.LogIn(userName, password);
      return (_user != null);
    }

    // private static void PostPizza()
    // {
    //   //_pr.Post()
    // }

    // private static void GetAllToppings()
    // {
    //   foreach (var t in _pr.GetAllToppings())
    //   {
    //     System.Console.WriteLine(t.Name);
    //   }
    // }

    // private static void GetAllSizes()
    // {
    //   foreach (var s in _pr.GetAllSizes())
    //   {
    //     System.Console.WriteLine(s.Name);
    //   }
    // }

    // private static void GetAllCrusts()
    // {
    //   foreach (var c in _pr.GetAllCrusts())
    //   {
    //     System.Console.WriteLine(c.Name);
    //   }
    // }

    // private static void GetAllPizzas()
    // {

    //   foreach (var p in _pr.GetAllPizzas())
    //   {
    //     System.Console.WriteLine(p);
    //   }
    // }
  }
}
