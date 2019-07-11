using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Area : IArea
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, Area> Directions { get; set; }
    public List<Character> Characters { get; set; }

    public Area Go(string direction)
    {
      System.Console.Clear();
      if (Directions.ContainsKey(direction))
      {
        System.Console.WriteLine($"You travel {direction.ToUpper()} to {Directions[direction].Name}.");

        return Directions[direction];
      }
      System.Console.WriteLine("You can't go that way. Obviously.");
      return this;
    }

    public void Look(string thing)
    {
      //check room's items, characters, and things for match. Else print default line
      foreach (var i in Items)
      {
        if (i.Name.ToLower() == thing)
        {
          System.Console.WriteLine(i.Description);
          return;
        }
      }
      foreach (var c in Characters)
      {
        if (c.Name.ToLower() == thing)
        {
          System.Console.WriteLine(c.Description);
          return;
        }
      }
      System.Console.WriteLine("You don't need to look at that.");
      return;
    }

    public void AddDirection(string direction, Area area)

    {
      Directions.Add(direction, area);
      if (direction == "west")
      {
        area.AddDirection("east", this);
      }
      if (direction == "south")
      {
        area.AddDirection("north", this);
      }
    }

    public void AddItem(Item item)
    {
      Items.Add(item);
    }
    public void RemoveItem(Item item)
    {
      Items.Remove(item);
    }

    public void AddCharacter(Character c)
    {
      Characters.Add(c);
    }

    public Area(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Directions = new Dictionary<string, Area>();
      Characters = new List<Character>();
    }
  }
}
