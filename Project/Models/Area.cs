using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Area : IArea
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IArea> Directions { get; set; }

    public void AddDirection(string direction, Area area)
    {
      Directions.Add(direction, area);
      if (direction == "West")
      {
        area.AddDirection("East", this);
      }
      if (direction == "South")
      {
        area.AddDirection("North", this);
      }
    }

    public Area(string name, string description, List<Item> items)
    {
      Name = name;
      Description = description;
      Items = items;
      Directions = new Dictionary<string, IArea>();
    }
  }
}
