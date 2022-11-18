using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrarySystem
{
    class MainMenu
    {
        public static void DisplayMenu(MemberCollection memberCollection,ToolCollection toolCollection)
        {
            string selectMain;

            Console.WriteLine("Welcome to the Tool Library System\n\n");
            Console.WriteLine("==============Main Menu=============");
            Console.WriteLine("1.Staff login");
            Console.WriteLine("2.Member login");
            Console.WriteLine("0.Exit");
            Console.WriteLine("====================================");
            Console.Write("Select option from menu (0 to exit): ");

            do
            {
                selectMain = Console.ReadLine();
                if (selectMain == "1")
                {
                    
                    string userNameStaff;
                    string passwordStaff;

                    do
                    {
                        Console.WriteLine("Enter staff username: ");
                        userNameStaff = Console.ReadLine();
                        Console.WriteLine("Enter staff password: ");
                        passwordStaff = Console.ReadLine();
                        if (userNameStaff == "staff" && passwordStaff == "today123")
                        {
                            Console.Clear();
                            StaffMenu.DisplayMenu(memberCollection,toolCollection);
                        }
                        else
                        {
                            Console.WriteLine("This account is not existing.");

                        }
                    } while (userNameStaff != "staff" || passwordStaff != "today123");
                }
                else if (selectMain == "2")
                {



                    string userFirstName;
                    string userlastName;
                    string name;
                    string userPassword;
                    string password;
                    int result;
                    Member user;
                    bool isValid;

                    do
                    {
                        Console.WriteLine("Enter Member fisrt name: ");
                        userFirstName = Console.ReadLine();
                        Console.WriteLine("Enter Member last name: ");
                        userlastName = Console.ReadLine();
                        Console.WriteLine("Enter Member password: ");
                        userPassword = Console.ReadLine();

                        name = userFirstName + userlastName;
                        result = memberCollection.FindAMember(name);
                        password = memberCollection.SearchPassword(name);

                        if (result != -1 && userPassword == password)
                        {
                            user = memberCollection.GetAMemberInfo(name);
                            Console.Clear();
                            MemberMenu.DisplayMenu(memberCollection, toolCollection,user);
                            isValid = false;
                        }
                        else
                        {
                            Console.WriteLine("This account is not existing.");
                            isValid = true;

                        }
                    } while (isValid);



                }
                else if (selectMain == "0")
                {
                    Console.WriteLine("See you next time, Bye!");
                }
                else
                {

                    Console.WriteLine("Invalid input, try aganin. ");
                    Console.Write("Select option from menu (0 to exit): ");

                }





            } while (selectMain != "1" && selectMain != "2" && selectMain != "0");

        }
    }
}
