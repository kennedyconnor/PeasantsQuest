namespace CastleGrimtol.Project.Models
{
  class Lady : Character
  {
    public override void Talk()
    {
      System.Console.WriteLine(Dialogue["noTrinket"]);
    }

    public Lady() : base()
    {
      Name = "Woman";
      Description = "Typical pasty peasant woman, overbearing and judgemental. Obsessed with goods and land.";
      Dialogue.Add("noTrinket", @"She looks up. 
'Oh, hello. I seem to have lost my mother's heirloom. If you find it, would you please bring it to me?'");
    }
  }
}