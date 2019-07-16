namespace CastleGrimtol.Project.Models
{
  class Kerrek : Character
  {
    public bool isAlive = true;
    public override void Talk(Player CurrentPlayer)
    {
      if (isAlive)
      {
        System.Console.WriteLine(Dialogue["alive"]);
        CurrentPlayer.isAlive = false;
      }
      else
      {
        System.Console.WriteLine(Dialogue["dead"]);
      }
    }
    public Kerrek() : base()
    {
      Name = "Kerrek";
      Description = "It's the Kerrek, you moron! Get outta here!";
      Dialogue.Add("alive", @"'Me llamo Julio,' you begin... It seems only to further anger the already tempramental Kerrek. 
That stupid 'Learn Kerrek in 3 Weeks' cassette did nothing for you!
The Kerrek bonks you over the head and drives your skull into your ribcage.");
      Dialogue.Add("dead", "The Kerrek doesn't respond on accounts of being dead.");
    }
  }
}