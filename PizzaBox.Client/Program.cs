using System.Linq;
using System;
using System.Collections.Generic;
using PizzaBox.Client.Controllers;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
  internal class Program
  {
    private static UserController _uc = new UserController();
    private static OrderController _oc = new OrderController();
    private static StoreController _sc = new StoreController();
    private static User _user;
    private static Store _store;

    private static void Main(string[] args)
    {
      bool loggedIn = false;
      while (!loggedIn)
      {
        System.Console.WriteLine("Please select an option:");
        System.Console.WriteLine("1. Log in." + Environment.NewLine + "2. Create User.");
        int selection = Int32.Parse(System.Console.ReadLine());
        if (selection == 1) 
        {
          while (!loggedIn)
          {
            loggedIn = DoLoginRoutine();
            if (!loggedIn)
            {
              System.Console.WriteLine("Error with login, please try again.");
            }
          }
        }
        else if (selection == 2) { CreateUser(); }
        else { System.Console.WriteLine("Sorry, I didn't understand that."); }
      }
      bool stillUsing = true;
      while (stillUsing && !_user.IsStore)
      {
        System.Console.WriteLine("Please select an option:" + Environment.NewLine + "1. Create an order.");
        System.Console.WriteLine("2. See available stores." + Environment.NewLine + "3. See order history.");
        System.Console.WriteLine("4. Quit.");
        int selection = Int32.Parse(System.Console.ReadLine());
        if (selection == 1) { CreateOrder(); }
        else if (selection == 2) { ListStores(); }
        else if (selection == 3) { ShowOrderHistory(); }
        else 
        {
          System.Console.WriteLine("Exiting the program.");
          stillUsing = false;
        }
      }
      while (stillUsing && _user.IsStore)
      {
        _store = _sc.GetStore(_user.Address);
        System.Console.WriteLine("Please select an option: " + Environment.NewLine + "1. See store order history.");
        System.Console.WriteLine("2. See sales." + Environment.NewLine + "3. Quit.");
        int selection = Int32.Parse(System.Console.ReadLine());
        if (selection == 1) { ShowStoreOrderHistory(); }
        else if (selection == 2) { ShowStoreSales(); }
        else if (selection == 3)
        {
          System.Console.WriteLine("Exiting the program.");
          stillUsing = false;
        }
      }
    }

    private static void ShowStoreSales()
    {
      System.Console.WriteLine("Showing sales for store:");
      List<Order> orders = _uc.ViewStoreOrderHistory(_store.StoreId);
      int small = 0;
      int med = 0;
      int large = 0;
      decimal sum = 0.00M;
      foreach(Order o in orders)
      {
        foreach(Pizza p in o.Pizzas)
        {
          //TODO: Remove the hard coded sizes
          if (p.Size.Name.Equals("Small"))
          {
            small++;
          }
          else if (p.Size.Name.Equals("Medium"))
          {
            med++;
          }
          else
          {
            large++;
          }
        }
        sum += o.Price;
      }
      System.Console.WriteLine("This store has sold $" + sum + " worth of pizza.");
      System.Console.WriteLine('\t' + "Small: " + small);
      System.Console.WriteLine('\t' + "Medium: " + med);
      System.Console.WriteLine('\t' + "Large: " + large);

    }

    private static void ShowStoreOrderHistory()
    {
      System.Console.WriteLine("Please select an option:" + Environment.NewLine + "1. See orders for entire store.");
      System.Console.WriteLine("2. See orders for a specific client.");
      int selection = Int32.Parse(System.Console.ReadLine());
      if (selection == 1)
      {
        foreach(Order o in _sc.GetFullOrderHistory(_store.StoreId))
        {
          System.Console.WriteLine(o);
        }
      }
      else 
      {
        System.Console.WriteLine("Listing all users of this store:");
        int counter = 1;
        foreach(User u in _sc.GetAllCustomersForStore(_user.Id))
        {
          System.Console.WriteLine(counter + ". " + u.Name);
          counter++;
        }
        selection = Int32.Parse(System.Console.ReadLine());
        User selectedUser = _sc.GetAllCustomersForStore(_user.Id).ElementAt(selection);
        System.Console.WriteLine("Printing Order History for user " + selectedUser.Name);
        foreach(Order o in _uc.ViewCustOrderHistory(selectedUser.Id))
        {
          System.Console.WriteLine(o);
        }
      }
    }

    private static void ShowOrderHistory()
    {
      System.Console.WriteLine("Order history for user " + _user.Name + ":");
      foreach(Order o in _uc.ViewCustOrderHistory(_user.Id))
      {
        System.Console.WriteLine(o);
      }
    }

    private static void ListStores()
    {
      int counter = 1;
      foreach (Store s in _uc.ViewStores())
      {
        System.Console.WriteLine(counter + ". " + s.StoreName + " " + s.Address);
        counter++;
      }
    }

    private static void CreateOrder()
    {
      Order newOrder = new Order();
      long storeID = GetStoreSelection();
      _store = _uc.SetStore(storeID);
      newOrder.CustomerId = _user.Id;
      newOrder.StoreId = _store.StoreId;
      bool createOrder;
      (createOrder, newOrder.Pizzas) = GetPizzaSelections(newOrder);
      if (createOrder)
      {
        System.Console.WriteLine("Creating new order.");
      }
      else 
      {
        System.Console.WriteLine("Canceling out of order.");
        _oc.RemoveOrder(newOrder);
      }
    }

    private static (bool, List<Pizza>) GetPizzaSelections(Order newOrder)
    {
      bool creatingMore = true;
      bool creatingOrder = false;
      List<Pizza> createdPizzas = new List<Pizza>();
      while (creatingMore)
      {
        System.Console.WriteLine("Please make a selection for your order:");
        System.Console.WriteLine("1. Add a pizza to the order." + Environment.NewLine + "2. Remove a pizza from the order.");
        System.Console.WriteLine("3. See order total." + Environment.NewLine + "4. Complete Order.");
        System.Console.WriteLine("5. Cancel out of order.");
        int selection = Int32.Parse(System.Console.ReadLine());
        //Create a pizza to add to the order
        if (selection == 1)
        {
          CreatePizzaFlow(createdPizzas, newOrder);
          creatingMore = true;
          creatingOrder = true;
        }
        //Remove a pizza from the order
        else if (selection == 2)
        {
          RemovePizzaFlow(createdPizzas);
          creatingMore = true;
          creatingOrder = false;
        }
        else if (selection == 3)
        {
          DisplayOrderTotal(createdPizzas);
        }
        //Complete the order
        else if (selection == 4)
        {
          creatingMore = false;
          creatingOrder = true;
        }
        //Cancle current order
        else
        {
          creatingMore = false;
          creatingOrder = false;
        }
      }
      return (creatingOrder, createdPizzas);
    }

    private static void DisplayOrderTotal(List<Pizza> createdPizzas)
    {
      System.Console.WriteLine("Current order:");
      decimal sum = 0.00M;
      foreach (Pizza p in createdPizzas)
      {
        sum += p.Price;
        System.Console.WriteLine(p);
      }
      System.Console.WriteLine("____________________________");
      System.Console.WriteLine("Total cost of order: " + sum + Environment.NewLine);
    }

    private static void RemovePizzaFlow(List<Pizza> createdPizzas)
    {
      int counter = 1;
      System.Console.WriteLine("Please select a pizza to remove:");
      foreach (Pizza p in createdPizzas)
      {
        System.Console.WriteLine(counter + ". " + p);
        counter++;
      }
      int selection = Int32.Parse(System.Console.ReadLine());
      createdPizzas.Remove(createdPizzas.ElementAt(selection-1));
      System.Console.WriteLine("Pizza removed.");
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
      _uc.SetStore(stores.ElementAt(selection-1).StoreId);
      _store = stores.ElementAt(selection-1);
      return stores.ElementAt(selection-1).StoreId;
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
        goodNewUser = _uc.CreateUserAccount(userName, password, fullName, address, phone, false);
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

    private static void CreatePizzaFlow(List<Pizza> createdPizzas, Order newOrder)
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
      Size selectedSize = sizes.ElementAt(selection-1);
      counter = 1;
      System.Console.WriteLine("What type of crust would you like?");
      List<Crust> crusts = _sc.GetAvailableCrusts();
      foreach (Crust c in crusts)
      {
        System.Console.WriteLine(counter + ". " + c.Name);
        counter++;
      }
      selection = Int32.Parse(System.Console.ReadLine());
      Crust selectedCrust = crusts.ElementAt(selection-1);
      counter = 1;
      bool choosingToppings = true;
      List<Topping> availableToppings = _sc.GetAvailableToppings();
      List<Topping> selectedToppings = new List<Topping>();
      while (choosingToppings)
      {
        System.Console.WriteLine("What topping would you like to add?");
        System.Console.WriteLine("0. No more toppings.");
        counter = 1;
        foreach (Topping t in availableToppings)
        {
          System.Console.WriteLine(counter + ". " + t.Name);
          counter++;
        }
        selection = Int32.Parse(System.Console.ReadLine());
        if (selection == 0)
        {
          choosingToppings = false;
        }
        else
        {
          selectedToppings.Add(availableToppings.ElementAt(selection-1));
          availableToppings.Remove(availableToppings.ElementAt(selection-1));
        }
      }
      List<PizzaTopping> pizzaToppingList = new List<PizzaTopping>();
      Pizza userPizza = new Pizza();
      foreach (Topping t in selectedToppings)
      {
        pizzaToppingList.Add(new PizzaTopping()
        {
          PizzaId = userPizza.Id,
          Pizza = userPizza,
          Id = DateTime.Now.Ticks,
          Topping = t
        });
      }
      userPizza.UserId = _user.Id;
      userPizza.Crust = selectedCrust;
      userPizza.Size = selectedSize;
      userPizza.Toppings = pizzaToppingList;
      //~!@~!@~!@~!@~!@~!@~!@~!@~!@~!@~!@~!@~!@~!@~!@
      //        SETTING ORDER. MIGHT NEED TO MOVE UP
      //!@#!@#!@#!@#!@#!@#!@#!@#!@#!@#!#!@#!@#!@#!#!@
      userPizza.Order = newOrder;
      userPizza.Crust.Pizzas.Add(userPizza);
      userPizza.Size.Pizzas.Add(userPizza);
      userPizza.Order.StoreId = _store.StoreId;
      userPizza.Order.Pizzas.Add(userPizza);
      createdPizzas.Add(userPizza);
      _oc.CreatePizza(userPizza);
    }
  }
}
