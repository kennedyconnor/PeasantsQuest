namespace CastleGrimtol.Project.Models
{
  class KerrekDomain : Area
  {
    public void UseSword(Player CurrentPlayer)
    {
      System.Console.WriteLine(@"You smote the Kerrek! He lays there stinking.
A light rain heralds the washing free of the Kerrek's grip on the land.
You're feeling pretty good, though, so the artless symbolism doesn't bug you. 
");
      Character kerrek = Characters.Find(c => c.Name.ToLower() == "kerrek");
      kerrek.Description = "The Kerrek lays there. You see his cool golden belt glinting in the sun.";
      Item belt = new Item("Belt", "Phew! This thing stinks like all getout. Why couldn't the Kerrek have kidnapped a hot wench or something that you could have saved?", "You claim the Kerrek's cool belt as your trophy. It stinks just like him! You start to miss him, a little.");
      Items.Add(belt);
    }

    public KerrekDomain()
    {
      Name = "The Kerrek's Domain";
      Description = "The Kerrek is stomping around angrily in a clearing covered in bramblevine and flattened grass. And it smells like a public latrine.";

      UseCases["sword"] = UseSword;
    }
  }
}