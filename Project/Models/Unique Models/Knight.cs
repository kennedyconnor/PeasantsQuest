namespace CastleGrimtol.Project.Models
{
  class Knight : Character
  {
    public override void Talk()
    {
      System.Console.WriteLine(Dialogue["none"]);
    }
    public Knight() : base()
    {
      Name = "Knight";
      Description = "He looks way cooler than you.";
      Dialogue.Add("none", @"
You explain your situation to the knight. That Trogdor burninated your cottage and you've sworn revenge. You ask for passage up the mountain to settle your score. 
'Hang on there, Trogdorkilla, ' says the knight. 'I can only allow actual peasants up the mountain pass to face Trogdor. And you CLEARLY are not one.'
'Look, Dragonheart...'
'You don't STINK like a peasant.'
'You don't DRESS like a peasant.'
'And you're definitely not ON FIRE like a peasant.'
'Once you're those 3 things, come back and maybe we can talk.'
      ");
    }
  }
}