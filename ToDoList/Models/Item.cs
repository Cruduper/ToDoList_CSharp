using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public string Description { get; set; }
    public int Id { get; } // public int Id = 1
    private static List<Item> _instances = new List<Item> { };

    public Item(string description)
    {
      Description = description;
      _instances.Add(this);
      Id = _instances.Count; // Id += 1;
    }

    public static Item Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public static List<Item> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static void DeleteItem(int id)
    {
      _instances.RemoveAt(id);
    }
  }
}
