namespace CastleGrimtol.Project.Models
{
  class PeacefulMeadow : Area
  {


    public override Item TakeItem(string input)
    {
      if (input == "berries" || input == "berry")
      {
        Item item = Items.Find(i => i.Name.ToLower() == "trinket");
        System.Console.WriteLine(item.GetMessage);
        return item;
      }
      return null;
    }
    public PeacefulMeadow() : base()
    {
      Name = "Peaceful Meadow";
      Description = "You arrive at a peaceful meadow with what appear to be some crunch berry bushes, pregnant with mystery.";

    }
  }
}