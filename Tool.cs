using System;
using System.Collections.Generic;
using System.Text;

namespace ToolLibrarySystem
{
    class Tool
    {
        public string Category { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public int Quantity { get; set; }
        public int TimesBeBorrowed { get; set; }

        public Tool()
        {

        }
        
        public Tool(string name,string category, string type,int quantity)
        {
            Name = name;
            Category = category;
            Type = type;
            Quantity = quantity;
            TimesBeBorrowed = 0;
            User = "None";
        }

    }
}
