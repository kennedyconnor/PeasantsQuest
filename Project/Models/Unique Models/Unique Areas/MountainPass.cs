namespace CastleGrimtol.Project.Models
{
  class MountainPass : Area
  {


    public override void Checks(Player CurrentPlayer)
    {
      if (CurrentPlayer.OnFire && CurrentPlayer.Looks && CurrentPlayer.Smells)
      {
        this.Description = "You've reached the mountain pass that leads to Trogdor's lair. The cool knight smiles at you.";
        this.AddDirection("west", new Area("Trogdor's Lair", "You're in a giant cavern which houses a giant dragon. You didn't shrink or anything."));
        Characters[0].Dialogue["talk"] = @"	
'Lookin good, Mr. Peasant. Good luck with ol' Beefy Arm up there.'
This is it! You can finally get revenge on Trogdor! Nice work so far, stupid!";
      }
    }
    public MountainPass() : base()
    {
      Name = "The Mountain Pass";
      Description = "You've reached the mountain pass that leads to Trogdor's lair. A royal knight blocks the entrance.";
    }
  }
}