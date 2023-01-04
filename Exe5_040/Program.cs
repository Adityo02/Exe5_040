using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exe5_040
{
    class Node
    {
        public int rollNumber;
        public string adityo;
        public Node arya;
    }

    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void EnterNode()
        {
            int rollNo;
            string ad;
            Console.Write("\nEnter The Roll Number of The Student : ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter The Roll Name of The Student : ");
            ad = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = rollNo;
            newnode.adityo = ad;

            if (START == null || rollNo <= START.rollNumber)
            {
                if((START != null) && (rollNo == START.rollNumber))
                {
                    Console.WriteLine();
                    return;
                }
                newnode.arya = START;
                START = newnode;
                return;
            }

            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (rollNo == current.rollNumber))
            {
                if(rollNo == current.rollNumber)
                {
                    Console.WriteLine();
                    return;
                }
                previous.arya = current;
                previous.arya = newnode;
            }
            newnode.arya = current;
            previous.arya = newnode;
        }

        public bool DeleteNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            previous.arya = current.arya;
            if (current == START)
                START = START.arya;
            return true;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
