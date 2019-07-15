using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string Description { get; set; }

    public string GetMessage { get; set; }

    public Item(string name, string description, string getMessage)
    {
      Name = name;
      Description = description;
      GetMessage = getMessage;
    }
  }
}