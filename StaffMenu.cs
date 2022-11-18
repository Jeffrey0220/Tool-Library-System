using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrarySystem
{
    class StaffMenu
    {
        public static void DisplayMenu(MemberCollection memberCollection,ToolCollection toolCollection)
        {
            string input;
            int select;

            Console.WriteLine("Welcome to the Tool Library\n\n");
            Console.WriteLine("==============staff Menu=============");
            Console.WriteLine("1.Add a tool");
            Console.WriteLine("2.Remove a tool");
            Console.WriteLine("3.Register a new member");
            Console.WriteLine("4.Remove a member");
            Console.WriteLine("5.Display all the members who are borrowing a tool");
            Console.WriteLine("6.Find a member's phone number");
            Console.WriteLine("0.Return to main menu");
            Console.WriteLine("====================================");
            Console.Write("Select option from menu (0 to exit): ");

            input = Console.ReadLine();
            bool isNumber = int.TryParse(input, out select);
            while (select>6||select<0|| !isNumber)
            {
                Console.WriteLine("Invalid input. Please enter a number from 0~6:");
                input = Console.ReadLine();
                isNumber = int.TryParse(input, out select);
            }

            if (select == 1)
            {
                AddTools(memberCollection,toolCollection);
                
            }
            else if (select == 2)
            {
                RemoveTools(memberCollection, toolCollection);
            }
            else if (select == 3)
            {
               

                RegisterNewMember(memberCollection, toolCollection);

                
            }
            else if (select == 4)
            {
                RemoveAMember(memberCollection, toolCollection);
            }
            else if (select == 5)
            {
                BorrowingMemberList(memberCollection, toolCollection);
            }
            else if (select == 6)
            {
                FindMemberPhoneNumber(memberCollection, toolCollection);
            }
            else if (select == 0)
            {
                Console.Clear();
                MainMenu.DisplayMenu(memberCollection, toolCollection);
            }
        }



        public static void AddTools(MemberCollection memberCollection, ToolCollection toolCollection)
        {

            string stop;
           
            do
            {

                toolCollection.Insert();
   
                Console.WriteLine("Press 'Enter' to Add more tools;\nEnter '0' Go back to Staff Menu; ");
                stop = Console.ReadLine();
                if (stop == "0")
                {
                    Console.Clear();
                    DisplayMenu(memberCollection, toolCollection);
                }
            } while (stop != "0");        

        }

        public static void RemoveTools(MemberCollection memberCollection, ToolCollection toolCollection)
        {

            string stop;

            do
            {
                toolCollection.Remove();

                Console.WriteLine("Press 'Enter' to Remove more tools;\nEnter '0' Go back to Staff Menu; ");
                stop = Console.ReadLine();
                if (stop == "0")
                {
                    Console.Clear();
                    DisplayMenu(memberCollection, toolCollection);
                }
            } while (stop != "0");

        }


        public static Member RegisterNewMember(MemberCollection memberCollection, ToolCollection toolCollection)
        {

            string stop;
            Member a;
            do
            {
                Console.WriteLine("\n===========================\nPleas register infomation of a new member.");
                Console.WriteLine("Enter member's first name: ");
                string f_name = Console.ReadLine();
                Console.WriteLine("Enter member's last name: ");
                string l_name = Console.ReadLine();
                Console.WriteLine("Enter member's phone number: ");
                string p_number = Console.ReadLine();
                Console.WriteLine("Enter member's password: ");
                string password = Console.ReadLine();




                a = new Member(f_name, l_name, p_number, password);
                
                memberCollection.Insert(a);
                memberCollection.Print();
                Console.WriteLine("Press 'Enter' for Another Registeration;\nEnter '0' Go back to Staff Menu; ");
                stop = Console.ReadLine();
                if (stop == "0")
                {
                    Console.Clear();
                    DisplayMenu(memberCollection, toolCollection);
                }
            } while (stop != "0");

            return a;

        }


        public static void RemoveAMember(MemberCollection memberCollection, ToolCollection toolCollection)
        {
            string name;
            string stop;
            string remove;
            do
            {
                Console.WriteLine("\n===========================\nRemove a member.");
                Console.WriteLine("Enter member's first name: ");
                string f_name = Console.ReadLine();
                Console.WriteLine("Enter member's last name: ");
                string l_name = Console.ReadLine();
                name = f_name + l_name;
                remove = memberCollection.RemoveAMember(name);

                Console.WriteLine(remove);
                Console.WriteLine("===================================\n");
                memberCollection.Print();
                Console.WriteLine("Press 'Enter' for Another remove;\nEnter '0' Go back to Staff Menu; ");
                stop = Console.ReadLine();
                if (stop == "0")
                {
                    Console.Clear();
                    DisplayMenu(memberCollection, toolCollection);
                }
            } while (stop != "0");
        }



        public static void BorrowingMemberList(MemberCollection memberCollection, ToolCollection toolCollection)
        {

            string stop;


            memberCollection.BorrowingMemberList();
            do
            {   

                Console.WriteLine("\nEnter '0' Go back to Staff Menu; ");
                stop = Console.ReadLine();
                if (stop == "0")
                {
                    Console.Clear();
                    DisplayMenu(memberCollection, toolCollection);
                }
            } while (stop != "0");

        }

        public static void FindMemberPhoneNumber(MemberCollection memberCollection, ToolCollection toolCollection)
        {
            string name;
            string stop;
            string phoneNumber;
            do
            {
                Console.WriteLine("\n===========================\nSearch phone number of a member.");
                Console.WriteLine("Enter member's first name: ");
                string f_name = Console.ReadLine();
                Console.WriteLine("Enter member's last name: ");
                string l_name = Console.ReadLine();
                name = f_name + l_name;
                phoneNumber=memberCollection.SearchPhoneNumber(name);
                if (phoneNumber=="Not existing")
                {
                    Console.WriteLine(f_name + " " + l_name + " is not an existing member, you cannot find the phone number.");
                }
                else
                {
                    Console.WriteLine(f_name + " " + l_name + "'s phone number: " + phoneNumber);
                }
              
                Console.WriteLine("===================================\n");

                Console.WriteLine("Press 'Enter' for Another search;\nEnter '0' Go back to Staff Menu; ");
                stop = Console.ReadLine();
                if (stop == "0")
                {
                    Console.Clear();
                    DisplayMenu(memberCollection, toolCollection);
                }
            } while (stop != "0");
        }


        
    }

}
