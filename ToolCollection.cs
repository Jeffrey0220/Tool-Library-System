using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolLibrarySystem
{
    class ToolCollection
    {
        
        public int count;


        string[] ToolCategories = { "GardeningTools", "FlooringTools", "FencingTools", "MeasuringTools", "CleaningTools", "PaintingTools", "ElectronicTools", "ElectricityTools", "AutomotiveTools" };

        string[][] ToolTypes ={
            new string[]{"LineTrimmers","LawnMoers","HandTools","Wheelbarrows","GardenPowerTools"},
            new string[]{"Scrapers","FloorLasers","FloorLevellingTools","FloorLevellingMaterials","FloorHandTools","TilingTools"},
            new string[]{"HandTools","ElectricFencing","SteelFencingTools","PowerTools","FencingAccessories"},
            new string[]{"DistanceTools","LaserMeasurer","MeasuringJugs","Temperature&HumidityTools","LevelingTools","Markers"},
            new string[]{"Draining","CarCleaning","Vacuum","PressureCleaners","PoolCleaning","FloorCleaning"},
            new string[]{"SandingTools","Brushes","Rollers","PaintRemovalTools","PaintScrapers","Sprayers"},
            new string[]{"VoltageTester","Oscilloscopes","ThermalImaging","DataTestTool","InsulationTesters"},
            new string[]{"TestEquipment","SafetyEquipment","BasicHandTools","CircuitProtection","CableTools"},
            new string[]{"Jacks","AirCompressors","BatteryChargers","SocketTools","Braking","Drivetrain"},
        };


        public Tool[][][] ToolTypesArrays =
            {
            new Tool[][]{ new Tool[20] , new Tool[20] ,new Tool[20] ,new Tool[20] ,new Tool[20] },
            new Tool[][]{ new Tool[20] , new Tool[20] ,new Tool[20] ,new Tool[20] ,new Tool[20] ,new Tool[20]},
            new Tool[][]{ new Tool[20] , new Tool[20] ,new Tool[20] ,new Tool[20] ,new Tool[20] },
            new Tool[][]{ new Tool[20] , new Tool[20] ,new Tool[20] ,new Tool[20] ,new Tool[20] ,new Tool[20]},
            new Tool[][]{ new Tool[20] , new Tool[20] ,new Tool[20] ,new Tool[20] ,new Tool[20] ,new Tool[20]},
            new Tool[][]{ new Tool[20] , new Tool[20] ,new Tool[20] ,new Tool[20] ,new Tool[20] ,new Tool[20]},
            new Tool[][]{ new Tool[20] , new Tool[20] ,new Tool[20] ,new Tool[20] ,new Tool[20] },
            new Tool[][]{ new Tool[20] , new Tool[20] ,new Tool[20] ,new Tool[20] ,new Tool[20] },
            new Tool[][]{ new Tool[20] , new Tool[20] ,new Tool[20] ,new Tool[20] ,new Tool[20] ,new Tool[20]},
        };





        public ToolCollection()
        {
            count = 0;
    

            for (int i = 0; i < ToolTypesArrays.Length; i++)
            {
                for (int j = 0; j < ToolTypesArrays[i].Length; j++)
                {
                    for (int k = 0; k < ToolTypesArrays[i][j].Length; k++)
                    {
                        ToolTypesArrays[i][j][k] = new Tool();
                    }
                }
            }

        }


        private int ChooseCategory()
        {
            int num=1;
            string input;
            int choose;
            bool isNumber;

            do
            {
                Console.WriteLine("Enter a number to choose a tool category: ");
                foreach (string category in ToolCategories)
                {
                    Console.WriteLine(num + ". " + category);
                    num++;
                }
                input = Console.ReadLine();
                isNumber = int.TryParse(input, out choose);
                num = 1;
            } while (choose > ToolCategories.Length|| choose<=0 || !isNumber);
            return choose;

        }

        private int ChooseType(int c)
        {
            int num = 1;
            string input;
            int choose;
            bool isNumber;
            do
            {
                Console.WriteLine(ToolCategories[c]);
                Console.WriteLine("Enter a number to choose a tool Type: ");
                for(int i = 0; i < ToolTypes[c].Length; i++)
                {
                    Console.WriteLine(num + ". " + ToolTypes[c][i]);
                    num++;                    
                }
                input = Console.ReadLine();
                isNumber = int.TryParse(input, out choose);
                num = 1;
            } while (choose > ToolTypes[c].Length || choose <= 0 || !isNumber);
            return choose;            
        }

        
        
        
        
        
        
        public Tool[] FilterSameNameTools(string name)
        {   
            int q = 0;
                      
            for (int i = 0; i < ToolTypesArrays.Length; i++)
            {
                for (int j = 0; j < ToolTypesArrays[i].Length; j++)
                {
                    for (int k = 0; k < ToolTypesArrays[i][j].Length; k++)
                    {
                        if(ToolTypesArrays[i][j][k].Name == name)
                        {
                            q++;
                        }
                    }
                }
            }
            Tool[] sameTools = new Tool[q];
            for (int i = 0; i < ToolTypesArrays.Length; i++)
            {
                for (int j = 0; j < ToolTypesArrays[i].Length; j++)
                {
                    for (int k = 0; k < ToolTypesArrays[i][j].Length; k++)
                    {
                        if (ToolTypesArrays[i][j][k].Name == name)
                        {
                            q--;
                            sameTools[q] = ToolTypesArrays[i][j][k];
                            
                        }
                    }
                }
            }

            return sameTools;
        }



        public void Insert()
        {

            int c;
            int t;
            int q;
            int quantity;
            string input;
            bool isNumber;
            string name;
            int TypeQuantity=0;



            Console.WriteLine("Enter tool's name: ");
            name=Console.ReadLine();
            Tool[] sameNameTools = FilterSameNameTools(name);
            if (sameNameTools.Length!=0)
            {
                 
                do
                {
                    Console.WriteLine("It's an existing tool, How many do you want to add, enter a number,: ");

                    input = Console.ReadLine();
                    isNumber = int.TryParse(input, out q);
                } while (!isNumber);

                
                c =Array.IndexOf(ToolCategories, sameNameTools[0].Category);
                t = Array.IndexOf(ToolTypes[c], sameNameTools[0].Type);

                
                quantity = sameNameTools[0].Quantity + q;

                for (int i = 0; i < ToolTypesArrays[c][t].Length; i++)
                {
                    if (ToolTypesArrays[c][t][i].Name != null)
                    {
                        TypeQuantity++;
                    }
                }
                TypeQuantity += q;
                if (TypeQuantity > 20)
                {
                    Console.WriteLine($"Running out of space! Tool Library only has 20 slots for each type of tool, please add less than {q} or update the space.");
                }
                else
                {
                    count += q;
                    foreach (var tool in sameNameTools)
                    {
                        tool.Quantity += q;
                    }
                    for (int i = 0; i < ToolTypesArrays[c][t].Length; i++)
                    {

                        if (ToolTypesArrays[c][t][i].Name == null && q > 0)
                        {
                            ToolTypesArrays[c][t][i] = new Tool(name, ToolCategories[c], ToolTypes[c][t], quantity);
                            ToolTypesArrays[c][t][i].TimesBeBorrowed = sameNameTools[0].TimesBeBorrowed;
                            q--;
                        }
                    }
                    Console.WriteLine("Successfully added.");

                }                
                    
            }
            else
            {
                    c = ChooseCategory();
                    c--;
                    t=ChooseType(c);
                    t--;

                do {
                    Console.WriteLine("How many do you want to add, Enter a number: ");     
                    input = Console.ReadLine();
                    isNumber = int.TryParse(input, out q);
                    } while (!isNumber);

                quantity = q;
                

                for (int i = 0; i < ToolTypesArrays[c][t].Length; i++)
                {
                    if (ToolTypesArrays[c][t][i].Name != null)
                    {
                        TypeQuantity++;
                    }
                }
                TypeQuantity += q;
                if (TypeQuantity > 20)
                {
                    Console.WriteLine($"Running out of space! Tool Library only has 20 slots for each type of tool, please add less than {q} or update the space.");
                }
                else
                {
                    count += q;
                    for (int i = 0; i < ToolTypesArrays[c][t].Length; i++)
                    {

                        if (ToolTypesArrays[c][t][i].Name == null && q > 0)
                        {
                            ToolTypesArrays[c][t][i] = new Tool(name, ToolCategories[c], ToolTypes[c][t], quantity);
                            q--;
                        }
                    }
                    Console.WriteLine("Successfully added.");
                }
                                                
            }

            
            Print();
        }


        public void Remove()
        {
            int c;
            int t;
            int q;
            int quantity;

            string input;
            bool isNumber;
            string name;
            if (count !=0)
            {

               Console.WriteLine("Enter tool's name: ");
               name = Console.ReadLine();
               Tool[] sameNameTools = FilterSameNameTools(name);
                while (sameNameTools.Length==0)
               {
                    Console.WriteLine(name+" is not existing. Please enter an existing tool's name: ");
                    name = Console.ReadLine();
                    sameNameTools = FilterSameNameTools(name);

                }
               
               Console.WriteLine("There are " + sameNameTools.Length +" "+ name + " in tool library, How many do you want to remove: ");
               input = Console.ReadLine();
               isNumber = int.TryParse(input, out q);
               while (q > sameNameTools.Length || q <= 0|| !isNumber)
                {
                    Console.WriteLine("Please enter a valid number(0 < number <= {0}): ", sameNameTools.Length);
                    input = Console.ReadLine();
                    isNumber = int.TryParse(input, out q);
                }

                c = Array.IndexOf(ToolCategories, sameNameTools[0].Category);
                t = Array.IndexOf(ToolTypes[c], sameNameTools[0].Type);

                count -= q;
                quantity=sameNameTools[0].Quantity-q;
                foreach (var tool in sameNameTools)
                {
                    tool.Quantity = quantity;
                }
                for (int i = 0; i < ToolTypesArrays[c][t].Length; i++)
                {

                    if (ToolTypesArrays[c][t][i].Name == name && q > 0)
                    {
                        ToolTypesArrays[c][t][i] = new Tool();
                        q--;
                    }
                }


                Console.WriteLine("Successfully removed.");
                Print();
            }
            else
            {
                Console.WriteLine("Tool library is empty.");
            }
        }


        public string[] BorrowTools(Member member)
        {
            int c;
            int t;
            int q;
            int b=0;
            string input;
            bool isNumber;
            string[] borrowed = new string[] { };
            string name;
            if (count != 0)
            {

                Console.WriteLine("Enter tool's name: ");
                name = Console.ReadLine();
                Tool[] sameNameTools = FilterSameNameTools(name);

                while (sameNameTools.Length == 0)
                {
                    Console.WriteLine(name + " is not existing. Please enter an existing tool's name: ");
                    name = Console.ReadLine();
                    sameNameTools = FilterSameNameTools(name);

                }

                for(int i = 0; i < sameNameTools.Length; i++)
                {
                    if (sameNameTools[i].User == "None")
                    {
                        b++;
                    }
                }
               
                if(b==0){
                    Console.WriteLine("There are no " + name + " available at this moment, Sorry.");
                    return borrowed;
                }
                else
                {
                    Console.WriteLine("There are " + b + " " + name + " available.");
                    Console.WriteLine("How many do you want to borrow:");
                    input = Console.ReadLine();
                    isNumber = int.TryParse(input, out q);
                    if (member.Limit==0)
                    {
                        Console.WriteLine("You've borrowd 5 tools already, cannot borrow any more.");
                        return borrowed;
                    }
                    else if(q > member.Limit)
                    {
                        Console.WriteLine($"Out of your limit, only can borrow {member.Limit} more.");
                        return borrowed;
                    }
                    else
                    {
                        while (q > b || q <= 0 || !isNumber)
                        {
                            Console.WriteLine($"There are {b} {sameNameTools[0].Name} is available, How many do you want to borrow:" );
                            input = Console.ReadLine();
                            isNumber = int.TryParse(input, out q);
                        }

                        c = Array.IndexOf(ToolCategories, sameNameTools[0].Category);
                        t = Array.IndexOf(ToolTypes[c], sameNameTools[0].Type);

                        borrowed = new string[q];
                        int increaseBorrowedTimes = q;
                        for (int i = 0; i < ToolTypesArrays[c][t].Length; i++)
                        {

                            if (ToolTypesArrays[c][t][i].Name == name && ToolTypesArrays[c][t][i].User == "None" && q > 0)
                            {
                                ToolTypesArrays[c][t][i].User = member.FirstName + " " + member.LastName;
                                ToolTypesArrays[c][t][i].TimesBeBorrowed += increaseBorrowedTimes;
                                q--;
                                borrowed[q] = ToolTypesArrays[c][t][i].Name;
                            }
                        }
                       
                        Console.WriteLine("Successfully borrowed.");
                    
                        return borrowed;
                    }
                    
                }
               
            }
            else
            {
                Console.WriteLine("Tool library is empty.");
                return borrowed;
            }

        }


        public void ReturnATool(string returnToolName,Member member)
        {
            int c;
            int t;
            int q = 1;
            string userName= member.FirstName + " " + member.LastName;
            Tool[] sameNameTools = FilterSameNameTools(returnToolName);
            c = Array.IndexOf(ToolCategories, sameNameTools[0].Category);
            t = Array.IndexOf(ToolTypes[c], sameNameTools[0].Type);
            for (int i = 0; i < ToolTypesArrays[c][t].Length; i++)
            {

                if (ToolTypesArrays[c][t][i].Name == returnToolName && ToolTypesArrays[c][t][i].User == userName && q > 0)
                {
                    ToolTypesArrays[c][t][i].User = "None";
                    q--;                
                }
            }         
        }


        
        public Tool[] BorrowedTools()
        {        
            int amount = 0;
            int index = 0;

            for (int i = 0; i < ToolTypesArrays.Length; i++)
            {
                for (int j = 0; j < ToolTypesArrays[i].Length; j++)
                {
                    for (int k = 0; k < ToolTypesArrays[i][j].Length-1; k++)
                    {
                        if (ToolTypesArrays[i][j][k].TimesBeBorrowed != 0)
                        {                            
                            amount++;
                        }
                    }        
                }
            }
            Tool[] borrowedTools=new Tool[amount];
            for (int i = 0; i < ToolTypesArrays.Length; i++)
            {
                for (int j = 0; j < ToolTypesArrays[i].Length; j++)
                {
                    for (int k = 0; k < ToolTypesArrays[i][j].Length - 1; k++)
                    {
                        if (ToolTypesArrays[i][j][k].TimesBeBorrowed != 0)
                        {
                            borrowedTools[index] = ToolTypesArrays[i][j][k];
                            index++;
                        }
                    }
                }
            }
            return borrowedTools;
        }

        public void TopThreeBorrowedTools()
        {
            Tool[] tools = BorrowedTools();
            int index;
            
            string[] toolNames=new string[tools.Length];
            for(int i = 0; i < tools.Length; i++)
            {              
                toolNames[i] = tools[i].Name;
            }
            string[] uniqueToolNames= toolNames.Distinct().ToArray();
            Tool[] BorrowedUniqueNameTools=new Tool[uniqueToolNames.Length];
            for (int i=0; i<uniqueToolNames.Length;i++)
            {
                index = Array.IndexOf(toolNames, uniqueToolNames[i]);
                BorrowedUniqueNameTools[i] = tools[index];
            }
            DescendingQuicksort(BorrowedUniqueNameTools, 0, BorrowedUniqueNameTools.Length - 1);
           
            if (BorrowedUniqueNameTools.Length < 3)
            {
                Console.WriteLine($"No top 3 most frequently borrowed tools. Only {BorrowedUniqueNameTools.Length} tools have been borrowed.");
            }
            else
            {
                foreach (var tool in BorrowedUniqueNameTools)
                {
                    Console.Write(tool.Name + " " + tool.TimesBeBorrowed + "times, ");
                }
                Console.WriteLine();
                Console.WriteLine("Top3 most frequently borrowed tools list:");
                for (int i = 0; i < 3; i++)
                {

                    Console.WriteLine($"Top{i + 1}: " + BorrowedUniqueNameTools[i].Name + " is borrowed " + BorrowedUniqueNameTools[i].TimesBeBorrowed + " times.");
                }
            }      
        }




        public void DisplayTools()
        {
           int c;
            int t;
          
            c = ChooseCategory();
            c--;
            t = ChooseType(c);
            t--;


            Console.WriteLine("Display tools of: ");
            Console.WriteLine("Category: " + ToolCategories[c] + " => " + "Type: " + ToolTypes[c][t]);
            Console.WriteLine("=================================================================");
            for (int i = 0; i < ToolTypesArrays[c][t].Length; i++)
            {

                if (ToolTypesArrays[c][t][i].Name !=null  )
                {  
                    Console.WriteLine("Name: " + ToolTypesArrays[c][t][i].Name + ", Quantity: " + ToolTypesArrays[c][t][i].Quantity + ", User: " + ToolTypesArrays[c][t][i].User);
                }
                             
            }
            Console.WriteLine(count);          
        }

        public void Print()
        {
          
            for (int i = 0; i < ToolTypesArrays.Length; i++)
            {
                for (int j = 0; j < ToolTypesArrays[i].Length; j++)
                {
                    for (int k = 0; k < ToolTypesArrays[i][j].Length; k++)
                    {
                        Console.Write(" " + ToolTypesArrays[i][j][k].Name + ", ");
                    }
                }
            }
            Console.WriteLine(count);

          
            Console.WriteLine();

        }


        private static void DescendingQuicksort(Tool[] tools, int left, int right)
        {
            int i = left;
            int j = right;
            var pivotIndex = (left + right) / 2;

            while (i <= j)
            {
                while (tools[i].TimesBeBorrowed > tools[pivotIndex].TimesBeBorrowed)
                {
                    i++;
                }
                while (tools[j].TimesBeBorrowed < tools[pivotIndex].TimesBeBorrowed)
                {
                    j--;
                }

                if (i <= j)
                {
                    var tmp = tools[i];
                    tools[i] = tools[j];
                    tools[j] = tmp;
                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                DescendingQuicksort(tools, left, j);
            }
            if (right > i)
            {
                DescendingQuicksort(tools, i, right);
            }

        }

    }
    

}

