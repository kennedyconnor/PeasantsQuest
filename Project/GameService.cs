using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public Area CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public void GetUserInput()
    {

    }

    public void Go(string direction)
    {

    }

    public void Help()
    {

    }

    public void Inventory()
    {

    }

    public void Look()
    {

    }

    public void Quit()
    {

    }

    public void Reset()
    {

    }

    public void Setup()
    {

      //Items
      Item baby = new Item("Baby", "Awww! Peasant babies are adorable. No wonder they fetch such a pretty penny on the black market.");
      Item belt = new Item("Kerrek Belt", "Phew! This thing stinks like all getout. Why couldn't the Kerrek have kidnapped a hot wench or something that you could have saved?");
      Item robe = new Item("Peasant Robe", "A vintage peasant robe! Just like grampa used to wear.");
      Item sword = new Item("TrogSword", "The TrogSword is for real. Hands-down the coolest item in the game. You can't wait to lop off that beefy arm of Trogdor's with this guy.");
      Item trinket = new Item("Trinket", "This trinket is weird. It looks like it can either kill you or make you the hit of your Christmas party.");
      Item map = new Item("Map", "A map of Peasantry. The only remaining posession from your burninated cottage.");
      Item shirt = new Item("Shirt", "This has got to be your favorite T-shirt ever. Oh, the times you had at Scalding Lake. Canoeing, fishing, stoning heathens. What a Blast!");

      //Rooms
      Area a1 = new Area("The Stomping Grounds", "The Kerrek is stomping around angrily in a clearing covered in bramblevine and flattened grass. And it smells like a public latrine.", new List<Item> { belt });
      Area a2 = new Area("Some Berry Bushes", "A peaceful meadow with what appear to be four crunch berry bushes but you can't be sure.", new List<Item> { trinket });
      Area a3 = new Area("A Peasant Cottage", "There's a ranch-style thatched roof cottage here. It reminds you of your own, pre-burnination. A woman sits outside in a rocking chair, holding a swaddled baby.", new List<Item> { baby, robe });
      Area b1 = new Area("Pebble Lake", " There's definitely half a lake here with a sandy shore.", new List<Item> { sword });
      Area b2 = new Area("Mountain Pass", "You've reached the mountain pass that leads to Trogdor's lair. A royal knight blocks the entrance.", new List<Item> { });
      Area b3 = new Area("Your Burninated Cottage", "The remains of your thatched-roof cottage lie before you. Some of it is still burning. You swear revenge against Trogdor. ", new List<Item> { map });
      Area c2 = new Area("Trogdor's Posh Lair", "You're in a giant cavern which houses a giant dragon. You didn't shrink or anything.", new List<Item> { });


      //Relationships
      //automatically adds other half of relationship(East-West, North-South)
      a1.AddDirection("West", b1);
      a1.AddDirection("South", a2);
      a2.AddDirection("West", b2);
      a2.AddDirection("South", a3);
      a3.AddDirection("West", b3);
      b1.AddDirection("South", b2);
      b2.AddDirection("South", b3);
      b2.AddDirection("West", c2);




    }

    public void StartGame()
    {

    }

    public void TakeItem(string itemName)
    {

    }

    public void UseItem(string itemName)
    {

    }
  }
}