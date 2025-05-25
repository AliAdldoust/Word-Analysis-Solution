using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace Solution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst1 = new BinarySearchTree();
            string filePath = "Resources/sherlockHolmes.txt";

            InserWordsfromFile(bst1, filePath);

            //Console.WriteLine("\nWords in alphabetical order:");
            //bst1.DisplayInOrder();

            Console.WriteLine("\nAll Words and Occurrences:");
            bst1.DisplayAllWords();

            int uniqueWordsCount = bst1.CountUniqueWords();
            Console.WriteLine($"\nThe number of unique words is: {uniqueWordsCount}");

            //Console.WriteLine("\nThe words in descending order are:");
            //bst1.DisplayAllWordsDescending();

            bst1.DisplayLongestWord();
            bst1.DisplayMostFrequentWord();

            Console.WriteLine("\nEnter a word to find its frequency: ");
            string word2 = Console.ReadLine();
            bst1.DisplayWordFrequency(word2);

            Console.WriteLine("\nEnter a word to find its line numbers:");
            string word1 = Console.ReadLine();
            bst1.DisplayWordLineNumbers(word1);




        }
        static void InserWordsfromFile(BinarySearchTree bst, string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error, File not found.");
                return;
            }
            char[] delimiters = { ' ', ',', '"', ':', ';', '?', '!', '-', '.', '\'', '*' };
            int lineNumber = 0;

            foreach (string line in File.ReadLines(filePath))
            {
                lineNumber++;
                string[] wordsInLine = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                foreach (string word in wordsInLine)
                {
                    string cleanWord = word.ToLower(); // Convert to lowercase for consistency
                    if (Regex.IsMatch(cleanWord, @"\b(?:[a-z]{2,}|[ai])\b", RegexOptions.IgnoreCase))
                    {
                        bst.Insert(cleanWord, lineNumber);
                    }
                }
            }
        }

    }
}
