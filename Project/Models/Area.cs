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
    public Dictionary<string, System.Action<Player>> UseCases { get; set; }
    public List<Thing> Things { get; set; }

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

    public void Look(string thingToLookAt)
    {
      //check room's items, characters, and things for match. Else print default line
      foreach (var i in Items)
      {
        if (i.Name.ToLower() == thingToLookAt)
        {
          System.Console.WriteLine(i.Description);
          return;
        }
      }
      foreach (var c in Characters)
      {
        if (c.Name.ToLower() == thingToLookAt)
        {
          System.Console.WriteLine(c.Description);
          return;
        }
      }
      foreach (var t in Things)
      {
        if (t.Name.ToLower() == thingToLookAt)
        {
          System.Console.WriteLine(t.Description);
          return;
        }

      }
      System.Console.WriteLine("You don't need to look at that.");
      return;
    }

    public void Talk(string character, Player CurrentPlayer)
    {
      foreach (Character c in Characters)
      {
        if (c.Name.ToLower() == character)
        {
          if (character == "kerrek") { c.Talk(CurrentPlayer); }
          else { c.Talk(); }
          return;
        }
      }
      System.Console.WriteLine("It's sad when you have to make up people to talk to.");
    }

    public virtual Item TakeItem(string input)
    {
      Item item = Items.Find(i => i.Name.ToLower() == input);
      if (item != null)
      {
        System.Console.WriteLine(item.GetMessage);
      }
      System.Console.WriteLine();
      return item;
    }

    public void UseItem(string input, Player CurrentPlayer)
    {
      if (UseCases.ContainsKey(input))
      {
        UseCases[input](CurrentPlayer);
      }
      else
      {
        System.Console.WriteLine("No reason to use this here.");
      }
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
    public void RemoveCharacter(Character c)
    {
      Characters.Remove(c);
    }
    public virtual void Checks(Player CurrentPlayer)
    {

    }
    public Area(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Directions = new Dictionary<string, Area>();
      Characters = new List<Character>();
      UseCases = new Dictionary<string, System.Action<Player>>();
      Things = new List<Thing>();
    }

    public Area()
    {
      Items = new List<Item>();
      Directions = new Dictionary<string, Area>();
      Characters = new List<Character>();
      UseCases = new Dictionary<string, System.Action<Player>>();
      Things = new List<Thing>();
    }
  }
}
