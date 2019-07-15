namespace CastleGrimtol.Project.Models
{
  class PeasantCottage : Area
  {

    public void UseTrinket(Player CurrentPlayer)
    {
      Item baby = new Item("Baby", "Awww! Peasant babies are adorable. No wonder they fetch such a pretty penny on the black market.", @"'My riches!!' she screams and snatches the trinket. 
'Thanks, sucker! Here you go!' she shoves the baby into your hands and bolts out the door.
You later learn that she does this all the time and is wanted throughout the countryside.
That trinket probably didn't belong to her and who knows whose baby this is. Well, it's yours now. ");
      this.AddItem(baby);
      TakeItem("baby");
      CurrentPlayer.addItem(baby);
      CurrentPlayer.Inventory.Remove(CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == "trinket"));

      this.RemoveCharacter(Characters.Find(c => c.Name == "Woman"));
      this.Description = "You had a cottage once. A lot like this one. *sniff* Trogdor will pay!";
    }
    public PeasantCottage()
    {
      Name = "A Peasant Cottage";
      Description = "There's a ranch-style thatched roof cottage here. A woman sits outside in a rocking chair, holding a swaddled baby.";
      UseCases["trinket"] = UseTrinket;
    }
  }
}