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

        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (rollNo != current.rollNumber))
            {
                previous = current;
                current = current.arya;
            }
            if (current == null)
                return false;
            else
                return true;
        }
        public void Displays()
        {
            if (listEmpty())
                Console.WriteLine("\nThe Records in the List are : ");
            else
            {
                Console.WriteLine("\nThe Records in The List are ; ");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.arya)
                    Console.Write(currentNode.rollNumber + " "
                        + currentNode.adityo + "\n");
                Console.WriteLine();
            }
        }

        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. Enter a Record to The List");
                    Console.WriteLine("2. Delete a Record From The List");
                    Console.WriteLine("3. Displays all The Record in The List");
                    Console.WriteLine("4. EXIT");
                    Console.Write("\nEnter Your Choice (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch(ch)
                    {
                        case '1':
                            {
                                obj.EnterNode();
                            }
                            break;

                        case '2':
                            {
                                if(obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                Console.WriteLine("Enter The Roll Number of" +
                                    " The Student Whose Record is to be deleted: ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.DeleteNode(rollNo) == false)
                                    Console.WriteLine("\nRecord Not Found.");
                                else
                                    Console.WriteLine("Record With Roll Number" +

                                        +rollNo + "Deleted");
                            }
                            break;

                        case '3':
                            {
                                obj.Displays();
                            }
                            break;

                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid Option");
                                break;
                            }
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("\nCheck for the Value Entered");
                }
            }
        }
    }
}
