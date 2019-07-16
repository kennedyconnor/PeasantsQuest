using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;
using System;
using System.Threading;

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
      Area newArea = CurrentArea.Go(input[1]);
      newArea.Checks(CurrentPlayer);
      CurrentArea = newArea;
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
        CurrentArea.Talk(input[1], CurrentPlayer);
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
      Console.WriteLine("You head NORTH towards the mountain atop which TROGDOR lives.");
      Console.ReadKey();
      Console.Clear();
    }

    public void Setup()
    {
      //Items

      Item belt = new Item("Belt", "Phew! This thing stinks like all getout. Why couldn't the Kerrek have kidnapped a hot wench or something that you could have saved?", "You claim the Kerrek's cool belt as your trophy. It stinks just like him! You start to miss him, a little.");
      Item robe = new Item("Robe", "A vintage peasant robe! Just like grampa used to wear, and the only remaining posession from your burninated cottage. Stylishly smouldering.", @"It's still burning - now you'll LOOK like a peasant and be ON FIRE like a peasant. 
The fires of vengeance that burn in your heart help you ignore the pain from the literal flames on the robe.");
      Item sword = new Item("Sword", "The TrogSword is for real. Hands-down the coolest item in the game. You can't wait to lop off that beefy arm of Trogdor's with this guy.", @"Something tells you this is a good idea and you lob the little one into the lake.
You won't be arrested after all! The little guy has resurfaced safely, carrying a sword. 
You take the sword - Way to go, baby! 
Baby Dashing keeps on crawling headed off to a new life. 
He becomes Valedictorian of his graduating class, goes to Scalding Lake State, gets a degree in Advanced Peasantry and lands a job at Thatch-Pro: building better cottages for a better tomorrow.
You grow apart and the letters from him become fewer and fewer. 
He develops a severe mead problem and blames you for never being there.");
      Item trinket = new Item("Trinket", "This trinket is weird. It looks like it can either kill you or make you the hit of your Christmas party.", "You reach into the bush to snag you some berries but instead find a Super Trinket! These things are awesome! You have a sneaking suspicion that SOMEONE in this game will need this thing.");
      Item map = new Item("Map", "A map of Peasantry. The only remaining posession from your burninated cottage.", "");
      Item shirt = new Item("Shirt", "This has got to be your favorite T-shirt ever. Oh, the times you had at Scalding Lake. Canoeing, fishing, stoning heathens. What a Blast!", "");

      //Things


      //Rooms
      KerrekDomain a1 = new KerrekDomain();
      PeacefulMeadow a2 = new PeacefulMeadow();
      PeasantCottage a3 = new PeasantCottage();
      PebbleLake b1 = new PebbleLake();
      MountainPass b2 = new MountainPass();
      YourCottage b3 = new YourCottage();

      //Characters
      Kerrek kerrek = new Kerrek();
      Knight knight = new Knight();
      Lady lady = new Lady();

      a1.AddCharacter(kerrek);
      b2.AddCharacter(knight);
      a3.AddCharacter(lady);

      //Relationships
      //automatically adds other half of relationship(East-West, North-South)
      b1.AddDirection("west", a1);
      a1.AddDirection("south", a2);
      b2.AddDirection("west", a2);
      a2.AddDirection("south", a3);
      b3.AddDirection("west", a3);
      b1.AddDirection("south", b2);
      b2.AddDirection("south", b3);


      //Add Items to Areas
      // a1.AddItem(belt);
      a2.AddItem(trinket);
      b3.AddItem(robe);
      b1.AddItem(sword);

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
        if (CurrentArea.Name == "Trogdor's Lair") { FinalRoom(); }
        else if (CurrentPlayer.isAlive == false) { Die(); }
        else GetUserInput();
      }

    }

    public void Die()
    {
      Console.WriteLine();
      Console.WriteLine("You're dead. Congratulations!");
      Thread.Sleep(1000);
      Quit();
    }

    public void FinalRoom()
    {
      Console.WriteLine(@"This is it! You hurl the Trog-Sword with all your might at the sleeping Burninator.
Now you've done it! Trogdor's awake and the Trog-Sword doesn't seem to be doing a whole lot.
Your legs lock in fear, your eyes glaze over and you wish for some Depeasant adult undergarments. But you think you hear Trogdor whimpering!
Aw crap, that's you whimpering. At least your voice still works, I guess.");
      Console.ReadKey();
      Console.Clear();
      Console.WriteLine(@"You scream that your name is Rather Dashing and that Trogdor burninated your cottage and you're here for revenge!
'Sup, mortal,' booms Trogdor. 'I really appreciate you making the effort to come all the way up here and vanquish me and all. But, I'm kinda indestructible.'
'Yeah, I can't be killed. I'm surprised nobody mentioned that to you. I'll admit though, you've gotten farther than anybody else ever has. I bet they'll make a statue or something in honor of you somewheres.'
'I can honestly say it'll be a pleasure and an honor to burninate you, Rather Dashing.'
Aw that sure was nice of him!
The Trogdor uncermoniously burninates you.");
      Console.ReadKey();
      Console.Clear();
      Console.WriteLine(@"Congratulations! You've won! 
No one can kill Trogdor but you came closer than anybody ever! Way to go!

THE END");
      Console.ReadKey();

      Quit();
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
        CurrentPlayer.addItem(item);
        CurrentArea.Items.Remove(item);
      }

    }

    public void UseItem(string input)
    {
      if (CurrentPlayer.Inventory.Find(i => i.Name.ToLower() == input) != null)
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