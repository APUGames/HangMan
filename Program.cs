using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace HangmanGame
{

    class Program
    {


        static void Main(string[] args)
        {
            bool right = false;
            string randomWord;
            List<char>? currentLettersGuessed;
            int currentLettersRight;
            char letterGuessed;
            int amountOfTimesWrong;

            static void printHangman(int wrong)
            {
                if (wrong == 0)
                {
                    Console.WriteLine("\n+---+");
                    Console.WriteLine("    |");
                    Console.WriteLine("    |");
                    Console.WriteLine("    |");
                    Console.WriteLine("   ===");

                }
                else if (wrong == 1)
                {
                    Console.WriteLine("\n+---+");
                    Console.WriteLine("O   |");
                    Console.WriteLine("    |");
                    Console.WriteLine("    |");
                    Console.WriteLine("   ===");
                }
                else if (wrong == 2)
                {
                    Console.WriteLine("\n+---+");
                    Console.WriteLine("O   |");
                    Console.WriteLine("|   |");
                    Console.WriteLine("    |");
                    Console.WriteLine("   ===");
                }
                else if (wrong == 3)
                {
                    Console.WriteLine("\n+---+");
                    Console.WriteLine(" O   |");
                    Console.WriteLine("/|   |");
                    Console.WriteLine("     |");
                    Console.WriteLine("   ===");
                }
                else if (wrong == 4)
                {
                    Console.WriteLine("\n+---+");
                    Console.WriteLine(" O    |");
                    Console.WriteLine("/|\\   |");
                    Console.WriteLine("      |");
                    Console.WriteLine("   ===");
                }
                else if (wrong == 5)
                {
                    Console.WriteLine("\n+---+");
                    Console.WriteLine(" O   |");
                    Console.WriteLine("/|\\    |");
                    Console.WriteLine("/    |");
                    Console.WriteLine("   ===");
                }
                else if (wrong == 6)
                {
                    Console.WriteLine("\n+---+");
                    Console.WriteLine(" O    |");
                    Console.WriteLine("/|\\    |");
                    Console.WriteLine("/|\\    |");
                    Console.WriteLine("   ===");
                }

                // Cool beans


            }

            static int printWord(List<char> guessedLetters, String randomWord)
            {
                int counter = 0;
                int rightLetter = 0;
                Console.Write("\r\n");
                foreach (char c in randomWord)
                {
                    if (guessedLetters.Contains(c))
                    {
                        Console.Write(c + " ");
                        rightLetter++;
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    counter++;
                }
                return rightLetter;
            }

            static void printLines(String randomWord)
            {
                Console.Write("\r");
                foreach (char c in randomWord)
                {
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                    Console.Write("/u0305 ");
                }
            }

            Console.WriteLine("Welcome to hangman :)");
            Console.WriteLine("--------------------------");

            Random random = new Random();
            List<string> wordDictionary = new List<string> { "pikachu", "charmander", "bulbasaur", "squirtle", "sobble", "scorbunny", "grookey", "cyndaquil", "mudkip", "froakie", "chimchar", "turtwig", "torchic", "rowlet", "tepig", "totodile", "fennekin", "chespin", "chikorita", "treecko", "piplup", "snivy", "oshawott", "litten", "popplio", "fuecoco", "quaxly", "sprigatito" };
            int index = random.Next(wordDictionary.Count);
            randomWord = wordDictionary[index];
            foreach (char x in randomWord)
            {
                Console.Write("_ ");
            }

            int lengthOfWordToGuess = randomWord.Length;
            amountOfTimesWrong = 0;
            currentLettersGuessed = new List<char>();
            currentLettersRight = 0;
            while (amountOfTimesWrong != 6 && currentLettersRight != lengthOfWordToGuess)
            {

                Console.Write("\nLetters guessed so far: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + " ");
                }
                // Prompt user for input
                Console.WriteLine("Guess a letter: ");
                letterGuessed = Console.ReadLine()[0];
                // Check if letter has already been guessed
                if (currentLettersGuessed.Contains(letterGuessed))
                {
                    Console.Write("\"\\r\\nYou have already guessed this letter.");
                    printHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    printLines(randomWord);
                }
                else
                {
                    // Check if letter is in the word
                    right = false;
                    for (int i = 0; i < randomWord.Length; i++)
                    {
                        if (letterGuessed == randomWord[i])
                        {
                            right = true;
                        }
                    }
                }

                if (right)
                {
                    printHangman(amountOfTimesWrong);
                    currentLettersGuessed.Add(letterGuessed);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    Console.Write("\r\n");
                    printLines(randomWord);
                }

                else
                {
                    amountOfTimesWrong++;
                    currentLettersGuessed.Add(letterGuessed);
                    printHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    Console.Write("\r\n");
                    printLines(randomWord);
                }

                Console.WriteLine("Congratulations! You won!! ");
            }
        }

    }
}



