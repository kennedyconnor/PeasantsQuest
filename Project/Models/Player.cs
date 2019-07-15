using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;


namespace CastleGrimtol.Project.Models
{
  public class Player : IPlayer
  {
    public string PlayerName { get; set; }
    public List<Item> Inventory { get; set; }
    public bool Smells = false;
    public bool Looks = false;
    public bool OnFire = false;

    public void addItem(Item item)
    {
      Inventory.Add(item);
      System.Console.WriteLine($"{item.Name} added to your inventory.");
      updateStatus(item);
    }

    public void updateStatus(Item item)
    {
      if (item.Name == "Belt") { Smells = true; }
      if (item.Name == "Robe") { Looks = true; }
    }

    public Player(string name)
    {
      PlayerName = name;
      Inventory = new List<Item>();
    }
  }
}