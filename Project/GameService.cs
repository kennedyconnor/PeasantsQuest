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

    public void GetUserInput()
    {
      string[] input = Console.ReadLine().ToLower().Split(" ");

      switch (input[0])
      {
        case "go":
          Go(input);
          break;

        case "get":
        case "take":
          TakeItem(input);
          break;

        case "look":
          Look(input);
          break;

        case "talk":
        case "speak":
          Talk(input);
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
      Console.WriteLine();
      Console.WriteLine(CurrentArea.Description);
      Console.WriteLine();
    }

    public void Help()
    {

    }

    public void Inventory()
    {

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
        Console.WriteLine($"You try to talk to {input[1]}.");
        //CurrentArea.Talk(character);
      }
      else { Console.WriteLine("Don't talk to yourself."); }
    }

    public void Quit()
    {

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

      Item baby = new Item("Baby", "Awww! Peasant babies are adorable. No wonder they fetch such a pretty penny on the black market.");
      Item belt = new Item("Kerrek Belt", "Phew! This thing stinks like all getout. Why couldn't the Kerrek have kidnapped a hot wench or something that you could have saved?");
      Item robe = new Item("Peasant Robe", "A vintage peasant robe! Just like grampa used to wear.");
      Item sword = new Item("TrogSword", "The TrogSword is for real. Hands-down the coolest item in the game. You can't wait to lop off that beefy arm of Trogdor's with this guy.");
      Item trinket = new Item("Trinket", "This trinket is weird. It looks like it can either kill you or make you the hit of your Christmas party.");
      Item map = new Item("Map", "A map of Peasantry. The only remaining posession from your burninated cottage.");
      Item shirt = new Item("Shirt", "This has got to be your favorite T-shirt ever. Oh, the times you had at Scalding Lake. Canoeing, fishing, stoning heathens. What a Blast!");

      //Rooms

      Area a1 = new Area("The Stomping Grounds", "The Kerrek is stomping around angrily in a clearing covered in bramblevine and flattened grass. And it smells like a public latrine.");
      Area a2 = new Area("Some Berry Bushes", "You arrive at a peaceful meadow with what appear to be four crunch berry bushes but you can't be sure.");
      Area a3 = new Area("A Peasant Cottage", "There's a ranch-style thatched roof cottage here. A woman sits outside in a rocking chair, holding a swaddled baby.");
      Area b1 = new Area("Pebble Lake", " There's definitely half a lake here with a sandy shore.");
      Area b2 = new Area("The Mountain Pass", "You've reached the mountain pass that leads to Trogdor's lair. A royal knight blocks the entrance.");
      Area b3 = new Area("Your Burninated Cottage", "The remains of your thatched-roof cottage lie before you. Some of it is still burning. You swear revenge against Trogdor. ");
      Area c2 = new Area("Trogdor's Lair", "You're in a giant cavern which houses a giant dragon. You didn't shrink or anything.");


      //Characters
      Kerrek kerrek = new Kerrek();

      a1.AddCharacter(kerrek);




      //Relationships
      //automatically adds other half of relationship(East-West, North-South)

      a1.AddDirection("west", b1);
      a1.AddDirection("south", a2);
      a2.AddDirection("west", b2);
      a2.AddDirection("south", a3);
      a3.AddDirection("west", b3);
      b1.AddDirection("south", b2);
      b2.AddDirection("south", b3);
      b2.AddDirection("west", c2);


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

      bool running = true;

      while (running)
      {
        GetUserInput();

      }

    }

    public void TakeItem(string[] input)
    {

    }

    public void UseItem(string[] input)
    {

    }
  }
}