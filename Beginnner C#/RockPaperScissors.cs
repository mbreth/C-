// Classic game of Rock Paper Scissors in C#

using System;

namespace RockPaperScissors {
  class RockPaperScissors {
    public string[] choice = {"Rock", "Paper", "Scissors"};

    public void StartUp() {
      Console.Write("Welcome to ");
      foreach (string word in choice) {
        Console.Write("{0} ", word);
      }
    }
    
    public string BotChoice() {
      Random rand = new Random();
      int index = rand.Next(choice.Length);
      string Bot = choice[index];
      return Bot;
    }

    public void Game() {
      string UserChoice;
      int UserScore = 0;
      int BotScore = 0;
      int GameCounter = 0;
      bool ValidInput = true;
      while (GameCounter < 10) {
        Console.WriteLine("Please make a choice (rock, paper or scissors): ");
        string Bot = BotChoice();
        UserChoice = Console.ReadLine();
        UserChoice = char.ToUpper(UserChoice[0]) + UserChoice.Substring(1);
        switch (UserChoice) {
          case "Rock":
            ValidInput = true;
            break;
          case "Paper":
            ValidInput = true;
            break;
          case "Scissors":
            ValidInput = true;
            break;
          default:
            ValidInput = false;
            break;
        }
        if (ValidInput == false) {
          Console.WriteLine("Invalid input.");
          ValidInput = true;
        }
        if (UserChoice == Bot) {
          Console.WriteLine("Tie! Nobody wins!");
          GameCounter++;
        } else {
          // rock = 0, paper = 1, scissors = 2
          if (UserChoice == choice[0]) {
            if (Bot == "Paper") {
              Console.WriteLine("Bot wins!");
              BotScore++;
              GameCounter++;
            } else if (Bot == "Scissors") {
              Console.WriteLine("You win!");
              UserScore++;
              GameCounter++;
            }
          } else if (UserChoice == choice[1]) {
            if (Bot == "Rock") {
              Console.WriteLine("You win!");
              UserScore++;
              GameCounter++;
            } else if (Bot == "Scissors") {
              Console.WriteLine("Bot wins!");
              BotScore++;
              GameCounter++;
            }
          } else if (UserChoice == choice[2]) {
            if (Bot == "Rock") {
              Console.WriteLine("Bot wins!");
              BotScore++;
              GameCounter++;
            } else if (Bot == "Paper") {
              Console.WriteLine("You win!");
              UserScore++;
              GameCounter++;
            }
          }
        }
      }
      if (UserScore > BotScore) {
        Console.WriteLine("\nYou win the game!!\n\nYour score: {0}\n\nBot Score: {1}", UserScore, BotScore);
      } else if (BotScore > UserScore) {
        Console.WriteLine("\nThe Bot wins the game!!\n\nYour score: {0}\n\nBot Score: {1}", UserScore, BotScore);
      }
    }
  }
  
  class GameExecute {
    static void Main(string[] args) {
      RockPaperScissors rps = new RockPaperScissors();
      rps.StartUp();
      rps.Game();
    }
  }
}
