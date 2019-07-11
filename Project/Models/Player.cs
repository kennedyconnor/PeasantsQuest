using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get; set; }
    public List<Item> Inventory { get; set; }

    public void addItem(Item item)
    {
      Inventory.Add(item);
      System.Console.WriteLine($"{item.Name} added to your inventory.");
    }

    public Player(string name)
    {
      PlayerName = name;
      Inventory = new List<Item>();
    }
  }
}