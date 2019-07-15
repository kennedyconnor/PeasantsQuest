using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;
using System;

namespace CastleGrimtol.Project
{
  public class GameService : IGameService
  {
    public Area CurrentArea { get; set; }
    public Player CurrentPlayer { get; set; }
    public bool Running = true;

    public void GetUserInput()
    {
      string[] input = Console.ReadLine().ToLower().Split(" ");
      Console.WriteLine();
      switch (input[0])
      {
        case "go":
          Go(input);
          break;

        case "get":
        case "take":
          TakeItem(input[1]);
          break;

        case "look":
          Look(input);
          break;

        case "talk":
        case "speak":
          Talk(input);
          break;

        case "inventory":
          Inventory();
          break;

        case "use":
          UseItem(input[1]);
          break;

        case "help":
          Help();
          break;

        default:
          Console.WriteLine("Enter 'Help' for help, which you clearly need.");
          break;
      }
    }

    public void Go(string[] input)
    {
      if (input.Length < 2)
      {
        Console.WriteLine("Pretty sure you need a DIRECTION to go in. Type HELP for help.");
        return;
      }
      CurrentArea = CurrentArea.Go(input[1]);
      CurrentArea.Checks(CurrentPlayer);
      Console.WriteLine();
      Console.WriteLine(CurrentArea.Description);
      Console.WriteLine();
    }

    public void Help()
    {
      Console.WriteLine(@"
Use 'Look' to look around. You can look at individual things too!
Use 'Talk' to talk to people. No promise they'll talk back though.
Use 'Get' or 'Take' to get items.
Use 'Use' to use an item in your inventory.
Use 'Inventory' to look at your inventory.
Use 'Quit' to exit game.
      ");
    }

    public void Inventory()
    {
      foreach (Item item in CurrentPlayer.Inventory)
      {
        Console.WriteLine($"  {item.Name} --- {item.Description}");
      }
    }

    public void Look(string[] input)
    {
      if (input.Length > 1)
      {
        CurrentArea.Look(input[1]);
      }
      else { Console.WriteLine(CurrentArea.Description); }
    }

    public void Talk(string[] input)
    {
      if (input.Length > 1)
      {
        CurrentArea.Talk(input[1]);
      }
      else { Console.WriteLine("Don't talk to yourself."); }
    }

    public void Quit()
    {
      Running = false;
    }

    public void Reset()
    {

    }
    public void Intro()
    {
      Console.WriteLine(@"
      
Welcome to PEASANT'S QUEST


press any button to continue
      ");
      Console.ReadKey();
      Console.Clear();

      Console.WriteLine("YOU are Rather Dashing, a humble peasant living in the peasant kingdom of Peasantry.");

      Console.WriteLine();
      Console.WriteLine("You return home from a vacation on Scalding Lake only to find that TROGDOR THE BURNINATOR has burninated your thatched roof cottage along with all your goods and services.");
      Console.WriteLine();
      Console.WriteLine("With nothing left to lose, you swear to get revenge on the Wingaling Dragon in the name of burninated peasants everywhere. ");
      Console.WriteLine();
      Console.WriteLine("You head WEST towards the mountain atop which TROGDOR lives.");
      Console.ReadKey();
      Console.Clear();
    }

    public void Setup()
    {
      //Items

      Item baby = new Item("Baby", "Awww! Peasant babies are adorable. No wonder they fetch such a pretty penny on the black market.", "");
      Item belt = new Item("Belt", "Phew! This thing stinks like all getout. Why couldn't the Kerrek have kidnapped a hot wench or something that you could have saved?", "You claim the Kerrek's cool belt as your trophy. It stinks just like him! You start to miss him, a little.");
      Item robe = new Item("Robe", "A vintage peasant robe! Just like grampa used to wear.", "");
      Item sword = new Item("Sword", "The TrogSword is for real. Hands-down the coolest item in the game. You can't wait to lop off that beefy arm of Trogdor's with this guy.", "");
      Item trinket = new Item("Trinket", "This trinket is weird. It looks like it can either kill you or make you the hit of your Christmas party.", "You reach into the bush to snag you some berries but instead find a Super Trinket! These things are awesome! You have a sneaking suspicion that SOMEONE in this game will need this thing.");
      Item map = new Item("Map", "A map of Peasantry. The only remaining posession from your burninated cottage.", "");
      Item shirt = new Item("Shirt", "This has got to be your favorite T-shirt ever. Oh, the times you had at Scalding Lake. Canoeing, fishing, stoning heathens. What a Blast!", "");

      //Rooms

      Area a1 = new Area("The Stomping Grounds", "The Kerrek is stomping around angrily in a clearing covered in bramblevine and flattened grass. And it smells like a public latrine.");
      PeacefulMeadow a2 = new PeacefulMeadow();
      Area a3 = new Area("A Peasant Cottage", "There's a ranch-style thatched roof cottage here. A woman sits outside in a rocking chair, holding a swaddled baby.");
      Area b1 = new Area("Pebble Lake", " There's definitely half a lake here with a sandy shore.");
      MountainPass b2 = new MountainPass();
      Area b3 = new Area("Your Burninated Cottage", "The remains of your thatched-roof cottage lie before you. Some of it is still burning. You swear revenge against Trogdor. ");


      //Characters
      Kerrek kerrek = new Kerrek();
      Knight knight = new Knight();
      Lady lady = new Lady();

      a1.AddCharacter(kerrek);
      b2.AddCharacter(knight);
      a2.AddCharacter(lady);




      //Relationships
      //automatically adds other half of relationship(East-West, North-South)

      a1.AddDirection("west", b1);
      a1.AddDirection("south", a2);
      a2.AddDirection("west", b2);
      a2.AddDirection("south", a3);
      a3.AddDirection("west", b3);
      b1.AddDirection("south", b2);
      b2.AddDirection("south", b3);


      //Add Items to Areas
      a1.AddItem(belt);
      a2.AddItem(trinket);
      a3.AddItem(baby);
      a3.AddItem(robe);
      b1.AddItem(sword);
      b3.AddItem(map);

      //Player Init
      CurrentPlayer = new Player("Rather Dashing");
      CurrentPlayer.Inventory.Add(shirt);

      //starting position
      CurrentArea = b2;
    }

    public void StartGame()
    {
      Setup();
      Intro();
      Console.WriteLine($"{CurrentArea.Description}");

      while (Running)
      {
        GetUserInput();

      }

    }

    public void TakeItem(string input)
    {
      Item item = CurrentArea.TakeItem(input);
      if (item == null)
      {
        Console.WriteLine("You probably WISH you could get that.");
      }
      else
      {
        CurrentPlayer.Inventory.Add(item);
        CurrentArea.Items.Remove(item);
        Console.WriteLine($"{item.Name} placed in your inventory.");
      }

    }

    public void UseItem(string input)
    {
      if (CurrentPlayer.Inventory.Find(i => i.Name == input) != null)
      {
        CurrentArea.UseItem(input, CurrentPlayer);
      }
      else
      {
        Console.WriteLine("You don't even have one of those.");
      }
    }
  }
}