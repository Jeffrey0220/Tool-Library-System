using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrarySystem
{
    class MemberMenu
    {
        public static void DisplayMenu(MemberCollection memberCollection,ToolCollection toolCollection,Member member)
        {
            string input;
            int select;

            Console.WriteLine("Welcome to the Tool Library\n\n");
            Console.WriteLine("==============Member Menu=============");
            Console.WriteLine("1.Display tools of a type");
            Console.WriteLine("2.Borrow a tool");
            Console.WriteLine("3.Return a tool");
            Console.WriteLine("4.List tools I'm borrowing");
            Console.WriteLine("5.Display top three most frequently borrowed tools");
            Console.WriteLine("0.Return to main menu");
            Console.WriteLine("====================================");
            Console.Write("Select option from menu (0 to exit): ");
            input = Console.ReadLine();
            bool isNumber = int.TryParse(input, out select);
            while (select > 5 || select < 0 || !isNumber)
            {
                Console.WriteLine("Invalid input. Please enter a number from 0~5:");
                input = Console.ReadLine();
                isNumber = int.TryParse(input, out select);
            }

            if (select == 1)
            {
                DisplayTools(memberCollection,toolCollection, member);
            }else if (select == 2)
            {
                BorrowTools(memberCollection, toolCollection, member);
            }
            else if (select == 3)
            {
                ReturnATool(memberCollection, toolCollection, member);
            }
            else if (select == 4)
            {
                ListBorrowingTools(memberCollection, toolCollection, member);
            }
            else if (select == 5)
            {
                ListTopThreeBorrowedTools(memberCollection, toolCollection, member);
            }
           
            else if (select == 0)
            {
                Console.Clear();
                MainMenu.DisplayMenu(memberCollection,toolCollection);
            }
        }


        public static void DisplayTools(MemberCollection memberCollection, ToolCollection toolCollection, Member member)
        {

            string stop;

            do
            {
                toolCollection.DisplayTools();

                Console.WriteLine("Press 'Enter' to choose another type;\nEnter '0' Go back to Member Menu; ");
                stop = Console.ReadLine();
                if (stop == "0")
                {
                    Console.Clear();
                    DisplayMenu(memberCollection, toolCollection,member);
                }
            } while (stop != "0");

        }

        public static void BorrowTools(MemberCollection memberCollection, ToolCollection toolCollection, Member member)
        {

            string stop;
            string[] borrowedTools;

            do
            {
                borrowedTools = toolCollection.BorrowTools(member);
                if(borrowedTools.Length==0)
                {
                    
                }
                else
                {
                    member.BorrowTools(borrowedTools);
                }
               

                Console.WriteLine("Press 'Enter' to borrow another tool;\nEnter '0' Go back to Member Menu; ");
                stop = Console.ReadLine();
                if (stop == "0")
                {
                    Console.Clear();
                    DisplayMenu(memberCollection, toolCollection,member);
                }
            } while (stop != "0");

        }

        public static void ReturnATool(MemberCollection memberCollection, ToolCollection toolCollection, Member member)
        {

            string stop;
            string returenToolName;
           

            do
            {
                returenToolName = member.ReturnATool();
                if (returenToolName == "")
                {

                }
                else
                {
                    toolCollection.ReturnATool(returenToolName, member);
                }


                Console.WriteLine("Press 'Enter' to return another tool;\nEnter '0' Go back to Member Menu; ");
                stop = Console.ReadLine();
                if (stop == "0")
                {
                    Console.Clear();
                    DisplayMenu(memberCollection, toolCollection, member);
                }
            } while (stop != "0");

        }


        public static void ListBorrowingTools(MemberCollection memberCollection, ToolCollection toolCollection, Member member)
        {

            string stop;
            member.ListBorrowingTools();
            do
            {                
                Console.WriteLine("\nEnter '0' Go back to Member Menu; ");
                stop = Console.ReadLine();
                if (stop == "0")
                {
                    Console.Clear();
                    DisplayMenu(memberCollection, toolCollection, member);
                }
            } while (stop != "0");

        }


        public static void ListTopThreeBorrowedTools(MemberCollection memberCollection, ToolCollection toolCollection, Member member)
        {

            string stop;
            toolCollection.TopThreeBorrowedTools();
            

            do
            {
                Console.WriteLine("\nEnter '0' Go back to Member Menu; ");
                stop = Console.ReadLine();
                if (stop == "0")
                {
                    Console.Clear();
                    DisplayMenu(memberCollection, toolCollection, member);
                }
            } while (stop != "0");
        }
    }
}
