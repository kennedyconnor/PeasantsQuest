using System.Collections.Generic;

namespace CastleGrimtol.Project.Models
{
  public abstract class Character
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public Dictionary<string, string> Dialogue { get; set; }

    public virtual void Talk() { }

    public Character()
    {
      Dialogue = new Dictionary<string, string>();
    }

  }
}