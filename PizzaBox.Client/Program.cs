using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GetAllPizzas();
        }

        private static void GetAllPizzas()
        {
          var lp = new List<Pizza>()
          {
            new Pizza()
          };
          foreach (var p in lp)
          {
            System.Console.WriteLine(p);
          }
        }
    }
}
