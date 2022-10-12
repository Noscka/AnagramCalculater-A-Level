using System;
using System.Collections.Generic;

namespace AnagramCalculater_A_Level
{
	internal class Program
	{
		static int Main(string[] args)
		{
			while (true)
			{
				/* Get needed words */
				Console.Write("Input Word 1: ");
				string GetWord = Console.ReadLine().ToUpper();
				Console.Write("Enter Word 2: ");
				string MainWord = Console.ReadLine().ToUpper();

				/* Dictionary containing character count in the main word */
				Dictionary<char, int> LetterCount = new Dictionary<char, int>();
				foreach (char c in MainWord)
				{
					if (!LetterCount.ContainsKey(c))
						LetterCount[c] = 0;
					LetterCount[c] += 1;
				}

				/* If true, word can be made from main word, if false, word cannot be made from main word */
				bool Anograms = true;

				/* Foreach loop that will each word from the getword agains the letters of main word */
				foreach (char c in GetWord)
				{
					if (LetterCount.ContainsKey(c) && LetterCount[c] > 0)
						LetterCount[c] -= 1;
					else
					{
						Anograms = false;
						break;
					}
				}

				/* Check if anything is left */
				foreach (KeyValuePair<char, int> entry in LetterCount)
				{
					/* If any character has more then 0 left, means they aren't anograms */
					Console.WriteLine($"Letter: {entry.Key}, Amount Left: {entry.Value}");
					if (entry.Value < 0)
						Anograms = false;
				}

				/* different message for different messages */
				if (Anograms)
					Console.WriteLine($"`{GetWord}` is an anagram of `{MainWord}`");
				else
					Console.WriteLine($"`{GetWord}` is not an anagram of `{MainWord}`");

				/* Nicely exiting the program */
				Console.Write("Exit Program? [y/n]: ");
				char ExitInput = Console.ReadKey().KeyChar;
				if (ExitInput == 'y' || ExitInput == 'Y')
					break;
				Console.Write("\n\n");
			}
			return 0;
		}
	}
}
