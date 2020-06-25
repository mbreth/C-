// First big C# program

using System;
using System.Collections.Generic;

namespace Hangman {
  class Hangman {
    public string RandomWord;
    public bool Finished = false;
    public int counter = 0;
    public string WordCategory;

    public string PickingWords() {
      string[] words = {"ELEPHANT", "PYTHON", "SNAKE", "BATTLEFIELD", "DOG", "BEACH", "COMPUTER", "COFFEE","GREEN", "PURPLE", "BLUE", "YELLOW"};
      string[] animals = {"ELEPHANT", "SNAKE", "DOG", "EAGLE", "RHINO", "SHARK"};
      string[] morgan = {"PYTHON", "BEACH", "COMPUTER", "COFFEE", "BATTLEFIELD"};
      string[] colors = {"GREEN", "PURPLE", "BLUE", "YELLOW"};
      Random rand = new Random();
      int index = rand.Next(words.Length);
      RandomWord = words[index];
      foreach (string word in animals) {
        if (word == RandomWord) {
          WordCategory = "Animals";
        }
      }
      foreach (string word in morgan) {
        if (word == RandomWord) {
          WordCategory = "Morgan";
        }
      }
      foreach (string word in colors) {
        if (word == RandomWord) {
          WordCategory = "Colors";
        }
      }
      return words[index];
    }

    public void TakeAGuess() {
      string Word = RandomWord;
      Console.WriteLine("What is your guess that the word is?: ");
      string UserFinalGuess = Console.ReadLine();
      if (UserFinalGuess.ToUpper() == Word) {
        Console.WriteLine("Congrats! You guessed the word {0} correctly!", Word);
        Finished = true;
        counter *= 1500;
      } else {
        Console.WriteLine("Incorrect. Go back to guessing letters.");
      }
    }
    
    public void GameSequence() {
      List<char> GuessedLetters = new List<char>();
      Console.WriteLine("Word category: {0}", WordCategory);
      while (counter < 20 || Finished != true) {
        Console.WriteLine("Guess a letter in the word: ");
        char UserGuess = Console.ReadKey().KeyChar;
        UserGuess = char.ToUpper(UserGuess);
        string Word = RandomWord;
        bool alreadyExists = GuessedLetters.Contains(UserGuess);
        bool WasGuessCorrect = true;
        for (int i = 0; i < Word.Length; i++) {
          if (UserGuess == Word[i]) {
            if (alreadyExists) {
              Console.WriteLine("\n\n#####################");
              Console.WriteLine("#####################");
              Console.Write("You already guessed {0}.\n", UserGuess);
              Console.WriteLine("Guess again...");
              Console.WriteLine("#####################");
              Console.WriteLine("#####################\n");
              alreadyExists = false;
            } else {
              GuessedLetters.Add(Word[i]);
              counter++;
            }
          } 
        }
        for (int a = 0; a < Word.Length; a++) {
          if (UserGuess != Word[a]) {
            WasGuessCorrect = false;
          }
        }
        if (WasGuessCorrect == false) {
          Console.WriteLine("\nGuess was incorrect. Try again.");
          WasGuessCorrect = true;
        }
        Console.WriteLine("\nLetters guessed correctly: ");
        GuessedLetters.ForEach(Console.WriteLine);
        string UserGuessedLetters = string.Join("", GuessedLetters.ToArray());
        if (UserGuessedLetters == Word) {
          Console.WriteLine("Congrats! You guessed the word {0}!", Word);
          Finished = true;
          counter *= 1500;
        }
        if (counter > 0) {
          Console.WriteLine("\nYou guessed {0} letter(s) correctly", counter);
        }
        if (counter <= 10 && counter >= 4) {
          Console.WriteLine("Would you like to guess the whole word? (yes / no): ");
          string TakeGuess = Console.ReadLine();
          if (TakeGuess == "yes" || TakeGuess == "Yes") {
            TakeAGuess();
          } else {
            Console.WriteLine("Okay.");
          }
        }
      }
    }    
  }
  

  class Game {
    static void Main(string[] args) {
      Hangman h = new Hangman();
      h.PickingWords();
      h.GameSequence();
    }
  }
}
