using System;
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
    
    private long _storeId;
    public long StoreId
    {
        get { return _storeId; }
        set { _storeId = value; }
    }
    private string _address;
    public string Address
    {
        get { return _address; }
        set { _address = value; }
    }
    private string _phone;
    public string Phone
    {
        get { return _phone; }
        set { _phone = value; }
    }
    public Store()
    {
      StoreId = DateTime.Now.Ticks;    
    }
  }
}