using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Solution
{
    public class BinarySearchTree
    {
        private Node root;

        public BinarySearchTree()
        {
            root = null;
        }
        // This is an extra method for manuall insertion of words, if needed. However,
        // the insertion from text file is handled by "InserWordsfromFile" method in "Program" class.

        public void Insert(string word, int lineNumber)
        {
            root = InsertRec(root, word, lineNumber);

        }

        private Node InsertRec(Node root, string word, int lineNumber)
        {
            if (root == null)
            {
                Node newNode = new Node(word);
                newNode.LineNumbers.Add(lineNumber);
                return newNode;
            }
            else if (string.Compare(word, root.Word) < 0)
            {
                root.Left = InsertRec(root.Left, word, lineNumber);

            }
            else if (string.Compare(word, root.Word) > 0)
            {
                root.Right = InsertRec(root.Right, word, lineNumber);
            }
            else
            {
                root.Frequency++;
                if (!root.LineNumbers.Contains(lineNumber))
                {
                    root.LineNumbers.Add(lineNumber);
                }
            }

            return root;
        }

        public void DisplayInOrder()
        {
            DisplayInOrderRec(root);
        }
        private void DisplayInOrderRec(Node root)
        {
            if (root != null)
            {
                DisplayInOrderRec(root.Left);
                root.LineNumbers.Sort();
                Console.WriteLine($"Word: {root.Word}, Frequency: {root.Frequency}, Line Numbers: {string.Join(", ", root.LineNumbers)}");
                DisplayInOrderRec(root.Right);
            }
        }
        public int CountUniqueWords()
        {
            return CountUniqueWordsRec(root);
        }
        private int CountUniqueWordsRec(Node root)
        {
            if (root == null)
            { return 0; }

            int leftCount = CountUniqueWordsRec(root.Left);
            int rightCount = CountUniqueWordsRec(root.Right);
            return 1 + leftCount + rightCount;
        }

        public void DisplayAllWords()
        {
            DisplayAllWordsRec(root);
        }
        private void DisplayAllWordsRec(Node root)
        {
            if (root == null)
                return;
            DisplayAllWordsRec(root.Left);
            Console.WriteLine($"{root.Word}: {root.Frequency}");
            DisplayAllWordsRec(root.Right);
        }
        public void DisplayAllWordsDescending()
        {
            DisplayAllWordsDescendingRec(root);
        }
        private void DisplayAllWordsDescendingRec(Node root)
        {
            if (root == null)
                return;
            DisplayAllWordsDescendingRec(root.Right);
            Console.WriteLine($"{root.Word}: {root.Frequency}");
            DisplayAllWordsDescendingRec(root.Left);
        }

        public void DisplayLongestWord()
        {

            Node LongestWordNode = DisplayLongestWordRec(root);
            Console.WriteLine($"\nThe longest word is: {LongestWordNode.Word}");

        }
        private Node DisplayLongestWordRec(Node root)
        {
            if (root == null)
                return null;


            Node leftlongest = DisplayLongestWordRec(root.Left);
            Node rightlongest = DisplayLongestWordRec(root.Right);

            Node longest = root;
            if (leftlongest != null && leftlongest.Word.Length > longest.Word.Length)
            {
                longest = leftlongest;
            }
            if (rightlongest != null && rightlongest.Word.Length > longest.Word.Length)
            {
                longest = rightlongest;
            }
            return longest;
        }

        public void DisplayMostFrequentWord()
        {
            Node mostfreqeunt = DisplayMostFrequentWordRec(root);
            Console.WriteLine($"\nThe Most Frequent Word is: <{mostfreqeunt.Word}> with occurrence of {mostfreqeunt.Frequency}");
        }

        private Node DisplayMostFrequentWordRec(Node root)
        {
            if (root == null)
            {
                return null;
            }
            Node leftMostFrequent = DisplayMostFrequentWordRec(root.Left);
            Node rightMostFrequent = DisplayMostFrequentWordRec(root.Right);

            Node mostfrequent = root;
            if (leftMostFrequent != null && leftMostFrequent.Frequency >= mostfrequent.Frequency)
            {
                mostfrequent = leftMostFrequent;
            }
            if (rightMostFrequent != null && rightMostFrequent.Frequency >= mostfrequent.Frequency)
            {
                mostfrequent = rightMostFrequent;
            }
            return mostfrequent;
        }

        public void DisplayWordLineNumbers(string word)
        {
            Node node = DisplayWordLineNumbersRec(root, word);
            if (node != null)
            {
                Console.WriteLine($"Line Numbers of <{node.Word}>: " + string.Join(", ", node.LineNumbers));
            }
            else
            {
                Console.WriteLine("Word not found.");
            }
        }

        private Node DisplayWordLineNumbersRec(Node root, string word)
        {
            if (root == null)
            { return null; }


            int comparison = string.Compare(root.Word, word, StringComparison.OrdinalIgnoreCase);

            if (comparison > 0)
            {
                return DisplayWordLineNumbersRec(root.Left, word);
            }

            else if (comparison < 0)
            {
                return DisplayWordLineNumbersRec(root.Right, word);
            }

            else
            {
                return root;
            }
        }

        public void DisplayWordFrequency(string word)
        {
            Node node = DisplayWordLineNumbersRec(root, word);
            if (node != null)
            {
                Console.WriteLine($"The frequency of <{node.Word}> is: {node.Frequency}");
            }
            else
            {
                Console.WriteLine("Word not found.");
            }
        }
    }
}

