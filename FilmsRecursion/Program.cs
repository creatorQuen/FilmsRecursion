using System;
using System.Collections.Generic;

namespace FilmsRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Node.BoxSizes = new List<int>() { 25, 40 };
            Node qqq = new Node(100);
            qqq.CreateGraph();
            qqq.WriteAllEnds();
        }
    }
}
