namespace CastleGrimtol.Project.Models
{
  class YourCottage : Area
  {

    public YourCottage()
    {
      Name = "Your Burninated Cottage";
      Description = "The remains of your thatched-roof cottage lie before you. Some of it is still burning. You swear revenge against Trogdor.";
      Thing cottage = new Thing("Cottage", @"You look around the remains.
All your baubles and trinkets, your flasks and scrolls, your goblets and staffs! BURNINATED!!
The only possession you can find is your vintage peasant robe, still burning.");
      Things.Add(cottage);
    }
  }
}