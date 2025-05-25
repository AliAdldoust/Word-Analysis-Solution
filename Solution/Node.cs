using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution
{
    public class Node
    {
        private string _word;
        private int frequency;
        private List<int> lineNumbers;
        private Node left;
        private Node right;

        public Node(string word)
        {
            _word = word;
            frequency = 1; //initial one for the beginning of the process.
            lineNumbers = new List<int>();
            left = null;
            right = null;

        }
        public string Word
        {
            get { return _word; }
        }
        public int Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        public List<int> LineNumbers
        {
            get { return lineNumbers; }
        }

        public Node Left
        {
            get { return left; }
            set { left = value; }
        }

        public Node Right
        {
            get { return right; }
            set { right = value; }
        }



    }
}
