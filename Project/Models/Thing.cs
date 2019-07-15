namespace CastleGrimtol.Project.Models
{
  public class Thing
  {
    public string Name { get; set; }
    public string Description { get; set; }

    public Thing(string name, string description)
    {
      Name = name;
      Description = description;
    }



  }
}