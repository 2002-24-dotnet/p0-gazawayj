using System.Collections.Generic;
namespace PizzaBox.Domain.Models
{
  public class Store
  {
    private string _storeName;
    public string StoreName
    {
        get { return _storeName; }
        set { _storeName = value; }
    }
    
    private int _id;
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }
    private string _address;
    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }
    private int _phone;
    public int Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }
    /// <summary>
    /// Get available sizes for this store
    /// </summary>
    /// <returns>A dictionary containing the sizes</returns>
    public Dictionary<int, Size> GetSizes()
    {
      //TODO: implement
      return new Dictionary<int, Size>();
    }
    /// <summary>
    /// Get available crusts for this store
    /// </summary>
    /// <returns>A dictionary containing the sizes</returns>
    public Dictionary<int, Crust> GetCrusts()
    {
      //TODO: implement
      return new Dictionary<int, Crust>();
    }
    /// <summary>
    /// Get available toppings for this store
    /// </summary>
    /// <returns>A dictionary containing the toppings</returns>
    public Dictionary<int, Topping> GetToppings()
    {
      //TODO: implement
      return new Dictionary<int, Topping>();
    }
  }
}