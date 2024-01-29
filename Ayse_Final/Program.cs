using System;
using System.Collections.Generic;

public class Game
{
    private List<string> inventory = new List<string>();
    private string currentLocation = "Forest";
    private bool hasTreehouseKey = false;
    private bool hasExploredLake = false;
    private int incorrectAnswerCount = 0;
    private bool storyFound = false;

    private Dictionary<string, List<string>> roomItems = new Dictionary<string, List<string>>()
    {
        { "Forest", new List<string>() },
        { "Treehouse", new List<string> { "Banana", "Apple", "Pomegranate", "Pear", "Orange" } },
        { "Lake", new List<string>() },
        { "GuardianRoom", new List<string>() },
        { "Tent", new List<string> { "Flashlight", "Axe", "Food Container", "Blanket" } }
    };

    public Game()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Forest Adventure! You find yourself lost in a mysterious forest.");
        Console.WriteLine("Your goal is to escape this forest, but there's also a hidden story waiting to be uncovered.");
        Console.WriteLine("Press any key to begin your adventure...");
        Console.WriteLine("");
        Console.WriteLine(" ,_     _");
        Console.WriteLine(" |\\_,-~/");
        Console.WriteLine(" / _  _ |    ,--.");
        Console.WriteLine("(  @  @ )   / ,-'");
        Console.WriteLine(" \\  _T_/-._( (");
        Console.WriteLine(" /         `. \\");
        Console.WriteLine("|         _  \\ |");
        Console.WriteLine(" \\ \\ ,  /      |");
        Console.WriteLine("  || |-_\\__   /");
        Console.WriteLine(" ((_/`(____,-'");
        Console.WriteLine("");
        Console.WriteLine("Press any key to begin your adventure...");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("To navigate through the forest, you can use the W/A/S/D keys.");
        Console.WriteLine("Press Q to quit the game, E to interact with objects, and T to return to the Forest.");
        Console.WriteLine("Good luck, and be cautious while searching for the hidden story!");
        EnterLocation(currentLocation);
    }

    public void Start()
    {
        bool gameRunning = true;
        while (gameRunning)
        {
            Console.WriteLine($"\nCurrent location: {currentLocation}");
            Console.WriteLine("Choose an action:");
            Console.WriteLine("Use W/A/S/D to move, Q to quit, E to interact, T to return to the Forest:");

            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.W:
                    AttemptMove("Tent");
                    break;
                case ConsoleKey.A:
                    AttemptMove("GuardianRoom");
                    break;
                case ConsoleKey.S:
                    AttemptMove("Treehouse");
                    break;
                case ConsoleKey.D:
                    AttemptMove("Lake");
                    break;
                case ConsoleKey.T:
                    LeaveLocation();
                    break;
                case ConsoleKey.Q:
                    gameRunning = false;
                    Console.WriteLine("\nThank you for playing!");
                    break;
                case ConsoleKey.E:
                    Interact();
                    break;
                default:
                    Console.WriteLine("\nInvalid choice.");
                    break;
            }
        }
    }

    private void AttemptMove(string destination)
    {
        if (destination == "Treehouse" && !hasTreehouseKey)
        {
            Console.WriteLine("\nThe treehouse is locked. You need a key to enter.");
            Console.WriteLine("You must find that key first.");
        }
        else
        {
            EnterLocation(destination);
        }
    }

    private void EnterLocation(string location)
    {
        currentLocation = location;
        ChangeConsoleColor(location); // Konsol rengini değiştiren fonksiyonu çağırıyoruz
        Console.Clear();
        Console.WriteLine($"You are now in the {location}.");
        if (location == "Lake" && !hasExploredLake)
        {
            Console.WriteLine("You notice a shimmering object in the water. It could be something important.");
        }
        DisplayRoomItems();
        DisplayInventory(); // Envanteri gösteren fonksiyonu çağırıyoruz
        DisplayCatAsciiArt();
    }

    private void LeaveLocation()
    {
        currentLocation = "Forest";
        ChangeConsoleColor("Forest"); // Konsol rengini orman için ayarlıyoruz
        Console.Clear();
        Console.WriteLine("You are back in the Forest, contemplating your next move.");
        DisplayRoomItems();
        DisplayInventory(); // Envanteri gösteren fonksiyonu çağırıyoruz
        DisplayCatAsciiArt();
    }

    private void DisplayRoomItems()
    {
        Console.WriteLine("\nItems in this location:");
        List<string> items = roomItems[currentLocation];
        if (items.Count == 0)
        {
            Console.WriteLine("No items to be found here.");
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {items[i]}");
            }
        }
    }

    private void DisplayInventory()
    {
        Console.WriteLine("\nYour inventory:");
        if (inventory.Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
        }
        else
        {
            foreach (var item in inventory)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }

    private void ChangeConsoleColor(string location)
    {
        switch (location)
        {
            case "Forest":
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case "Treehouse":
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                break;
            case "Lake":
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case "GuardianRoom":
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case "Tent":
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Black;
                break;
            default:
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
        Console.Clear(); // Ekranı temizleyip renk değişikliğini hemen uyguluyoruz
    }

    private void DisplayCatAsciiArt()
    {
        Console.WriteLine("");
        Console.WriteLine("         .__....._             _.....__,");
        Console.WriteLine("            .\": o :':         ;': o :\".");
        Console.WriteLine("            `. `-' .'.       .'. `-' .'");
        Console.WriteLine("              `---'             `---'");
        Console.WriteLine("");
        Console.WriteLine("    _...----...      ...   ...      ...----..._");
        Console.WriteLine(" .-'__..-\"\"'----    `.  `\"`  .'    ----'\"\"-..__`-.");
        Console.WriteLine("'.-'   _.--\"\"'       `-._.-'       '\"\"--._   `-.`");
        Console.WriteLine("'  .-\"'                  :                  `\"-.  `");
        Console.WriteLine("  '   `.              _.'\"'._              .'   `");
        Console.WriteLine("        `.       ,.-'\"       \"'-.,       .'");
        Console.WriteLine("          `.                           .'");
        Console.WriteLine("            `-._                   _.-'");
        Console.WriteLine("                `\"'--...___...--'\"`");
        Console.WriteLine("");
    }

    private void Interact()
    {
        switch (currentLocation)
        {
            case "Lake":
                InteractWithLake();
                break;
            case "Tent":
                InteractWithItems("Tent");
                break;
            case "GuardianRoom":
                InteractWithGuardian();
                break;
            case "Treehouse":
                InteractWithItems("Treehouse");
                break;
            default:
                Console.WriteLine("There is nothing to interact with here.");
                break;
        }
    }

    private void InteractWithLake()
    {
        if (!hasExploredLake)
        {
            Console.WriteLine("\nDo you want to dive into the lake to investigate the shimmering object? (yes/no)");
            string choice = Console.ReadLine().ToLower();
            if (choice == "yes")
            {
                Console.WriteLine("You dive into the lake and discover a shiny key. It must be the Treehouse Key!");
                inventory.Add("Treehouse Key");
                hasTreehouseKey = true;
                hasExploredLake = true;
                Console.WriteLine("You wonder what this key unlocks.");
            }
            else
            {
                Console.WriteLine("You decide not to dive right now.");
            }
        }
        else
        {
            Console.WriteLine("You remember your earlier dive and decide there's nothing more to find.");
        }
    }

    private void InteractWithItems(string location)
    {
        Console.WriteLine($"\nSelect an item number to pick up or type '0' to exit ({currentLocation}):");
        int itemNumber;
        if (int.TryParse(Console.ReadLine(), out itemNumber) && itemNumber > 0 && itemNumber <= roomItems[location].Count)
        {
            string selectedItem = roomItems[location][itemNumber - 1];
            inventory.Add(selectedItem);
            roomItems[location].RemoveAt(itemNumber - 1);
            Console.WriteLine($"You picked up the {selectedItem}.");
            Console.WriteLine("You ponder over how this item could help you escape the forest.");
        }
        else if (itemNumber == 0)
        {
            Console.WriteLine("You exit the interaction.");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    private void InteractWithGuardian()
    {
        if (incorrectAnswerCount < 3)
        {
            Console.WriteLine("\nA mystical Guardian blocks your path. He asks a riddle:");
            Console.WriteLine("\"I bought one at the market, but when I got home, I had a thousand. Bring me one.\"");
            List<string> options = new List<string> { "Table", "Sugar", "Peanut", "Grape", "Potato" };
            if (inventory.Contains("Pomegranate"))
            {
                options.Add("Give Pomegranate to the Guardian");
            }

            foreach (var option in options)
            {
                Console.WriteLine($"- {option}");
            }

            string playerAnswer = Console.ReadLine().ToLower();
            if (playerAnswer == "give pomegranate to the guardian" && inventory.Contains("Pomegranate"))
            {
                Console.WriteLine("The Guardian smiles and steps aside, revealing a path leading out of the forest.");
                Console.WriteLine("Congratulations, you have solved the puzzle and escaped the forest!");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("The Guardian shakes his head. 'That is not the answer.'");
                incorrectAnswerCount++;
                if (incorrectAnswerCount >= 3)
                {
                    Console.WriteLine("The guard lost his patience and killed you by axing you in the back, knocking you to the ground, and hung your body on the tree to watch you. YOU LOSE!*.");
                    Console.WriteLine("Game Over!");
                    Environment.Exit(0);
                }
            }
        }
        else
        {
            Console.WriteLine("The Guardian, now impatient, refuses to let you pass.");
            Console.WriteLine("Game Over!");
            Environment.Exit(0);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
    }
}

