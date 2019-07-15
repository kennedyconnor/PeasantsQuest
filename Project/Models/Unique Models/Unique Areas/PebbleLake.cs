namespace CastleGrimtol.Project.Models
{
  class PebbleLake : Area
  {
    public void UseBaby(Player CurrentPlayer)
    {
      Item sword = TakeItem("sword");
      CurrentPlayer.addItem(sword);
      Item baby = CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == "baby");
      CurrentPlayer.Inventory.Remove(baby);


    }

    public PebbleLake()
    {
      Name = "Pebble Lake";
      Description = "There's definitely half a lake here with a sandy shore.";

      Thing lake = new Thing("Lake", "You peer into the blue waters of the lake. You're reminded of a certain Arthurian legend.?");

      Things.Add(lake);
      UseCases["baby"] = UseBaby;



    }
  }
}