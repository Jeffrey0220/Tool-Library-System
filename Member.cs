using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrarySystem
{
    class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int MemberKey { get; set; }
        public string[] BorrowedTools { get; set; }
        public int Limit { get; set; }
        public bool isBorrowing;
  


        public Member(string firstName, string lastName, string phoneNumber, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;         
            Password = password;
            Limit = 5;
            BorrowedTools = new string[Limit];
            isBorrowing = false;
        }

        public Member()
        {
            
        }

        public void BorrowTools(string[] tools)
        {
            isBorrowing = true;

            if (Limit > 0)
            {
                foreach(string tool in tools)
                {
                    BorrowedTools[Limit - 1] = tool;
                    Limit--;
                }
                Console.Write("Your borrowed tools' list: ");
                for (int i = 0; i < BorrowedTools.Length; i++)
                {
                    if (BorrowedTools[i]!= null)
                    {
                        Console.Write(BorrowedTools[i]+"; ");
                    }
                       
                }
             
                Console.WriteLine();
                Console.WriteLine($"You can borrow another {Limit} tools.");
            }
            else
            {
                Console.WriteLine("Out of borrowing limit, cannot borrow anymore.");
            }
        }

        public string ReturnATool()
        {
            int toolsNum;
            string name;        
            bool exist;
            int c = 1;
            string returnToolName="";
            toolsNum = BorrowedTools.Length - Limit;
            if (toolsNum == 0)
            {
                Console.WriteLine("you have no tools to return.");
                isBorrowing = false;
                return returnToolName;
                
            }
            else
            {
                Console.WriteLine($"you have {toolsNum} tools in your hands: ");
                
                for (int i = 0; i < BorrowedTools.Length; i++)
                {
                    if (BorrowedTools[i] != null)
                    {
                        Console.Write(BorrowedTools[i] + "; ");                      
                    }
                }
                Console.WriteLine("\nwhich one you want to return, please enter the name of the tool:");

                name = Console.ReadLine();
                exist = Array.Exists(BorrowedTools, element => element == name);
                while (!exist && name != null)
                {
                    Console.WriteLine("not a tool in your hands, please write a correct name:");
                    name = Console.ReadLine();
                    exist = Array.Exists(BorrowedTools, element => element == name);
                }

                for (int i = 0; i < BorrowedTools.Length; i++)
                {
                    if (BorrowedTools[i] == name && c > 0)
                    {
                        returnToolName = BorrowedTools[i];
                        BorrowedTools[i] = null;   
                        c--;
                        Limit++;
                    }
                }
                if (Limit == 5)
                {
                    isBorrowing = false;
                }

                return returnToolName;
            }

        }


        public void ListBorrowingTools()
        {

            int toolsNum;
     
            toolsNum = BorrowedTools.Length - Limit;

            Console.WriteLine($"you have {toolsNum} tools in your hands: ");

            for (int i = 0; i < BorrowedTools.Length; i++)
            {
                if (BorrowedTools[i] != null)
                {
                    Console.Write(BorrowedTools[i] + "; ");
                }
            }
        }
    }
}
