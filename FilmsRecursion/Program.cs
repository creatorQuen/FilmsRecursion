using System;
using System.Collections.Generic;

namespace FilmsRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            Node.BoxSizes = new List<int>() { 33, 50 };
            Node qqq = new Node(100);
            qqq.CreateGraph();
            qqq.WriteAllEnds();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();



            Result www = qqq.GetResult();

            foreach(int w in www.CurrentBoxes)
            {
                Console.Write(w + " ");
            }
            Console.WriteLine();
        }
    }
}
