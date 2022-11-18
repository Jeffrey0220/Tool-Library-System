using System;

namespace ToolLibrarySystem
{
    class Program
    {
    static void Main(string[] args)
    {
            // initial member 
            Member m1 = new Member("Xuefei", "Li", "34567", "xl123");
            Member m2 = new Member("Jane", "Fonda", "54321", "jf123");
            Member m3 = new Member("Json", "Scott", "12345", "js123");          
            Member m4 = new Member("Nancy", "Clark", "77889", "nc123");
            Member m5 = new Member("Sarah", "Ann", "99001", "sa123");

            // initial tools 
            Tool t1 = new Tool("ruler123", "MeasuringTools", "DistanceTools",3);
            Tool t2 = new Tool("ruler123", "MeasuringTools", "DistanceTools",3);
            Tool t3 = new Tool("ruler123", "MeasuringTools", "DistanceTools",3);
            Tool t4 = new Tool("clean123", "CleaningTools", "Vacuum",2);
            Tool t5 = new Tool("clean123", "CleaningTools", "Vacuum",2);
            Tool t6 = new Tool("bark123", "AutomotiveTools", "Braking",3);
            Tool t7 = new Tool("bark123", "AutomotiveTools", "Braking",3);
            Tool t8 = new Tool("bark123", "AutomotiveTools", "Braking",3);
            Tool t9 = new Tool("fence123", "FencingTools", "FencingAccessories",3);
            Tool t10 = new Tool("fence123", "FencingTools", "FencingAccessories",3);
            Tool t11= new Tool("fence123", "FencingTools", "FencingAccessories",3);
            Tool t12= new Tool("garden123", "GardeningTools", "LineTrimmers",3);
            Tool t13 = new Tool("garden123", "GardeningTools", "LineTrimmers",3);
            Tool t14 = new Tool("garden123", "GardeningTools", "LineTrimmers",3);
            Tool t15 = new Tool("flower123", "GardeningTools", "LineTrimmers",3);
            Tool t16 = new Tool("flower123", "GardeningTools", "LineTrimmers",3);
            Tool t17 = new Tool("flower123", "GardeningTools", "LineTrimmers",3);
            Tool t18 = new Tool("laser123", "FlooringTools", "FloorLasers",2);
            Tool t19 = new Tool("laser123", "FlooringTools", "FloorLasers",2);
            Tool t20 = new Tool("test123", "ElectricityTools", "TestEquipment",2);
            Tool t21 = new Tool("test123", "ElectricityTools", "TestEquipment",2);
            Tool t22 = new Tool("jack123", "AutomotiveTools", "Jacks",2);
            Tool t23 = new Tool("jack123", "AutomotiveTools", "Jacks",2);


            MemberCollection memberCollection = new MemberCollection();
            ToolCollection toolColletion = new ToolCollection();

            memberCollection.Insert(m1);
            memberCollection.Insert(m2);
            memberCollection.Insert(m3);
            memberCollection.Insert(m4);
            memberCollection.Insert(m5);
     

            toolColletion.ToolTypesArrays[3][0][0] = t1;
            toolColletion.count++;
            toolColletion.ToolTypesArrays[3][0][1] = t2;
            toolColletion.count++;
            toolColletion.ToolTypesArrays[3][0][2] = t3;
            toolColletion.count++;

           
            toolColletion.ToolTypesArrays[4][2][0] = t4;
            toolColletion.count++;
            toolColletion.ToolTypesArrays[4][2][1] = t5;
            toolColletion.count++;

            toolColletion.ToolTypesArrays[8][4][0] = t6;
            toolColletion.count++;
            toolColletion.ToolTypesArrays[8][4][1] = t7;
            toolColletion.count++;
            toolColletion.ToolTypesArrays[8][4][2] = t8;
            toolColletion.count++;


            toolColletion.ToolTypesArrays[2][4][0] = t9;
            toolColletion.count++;
            toolColletion.ToolTypesArrays[2][4][1] = t10;
            toolColletion.count++;
            toolColletion.ToolTypesArrays[2][4][2] = t11;
            toolColletion.count++;

         
            toolColletion.ToolTypesArrays[0][0][0] = t12;
            toolColletion.count++;
            toolColletion.ToolTypesArrays[0][0][1] = t13;
            toolColletion.count++;
            toolColletion.ToolTypesArrays[0][0][2] = t14;
            toolColletion.count++;
            toolColletion.ToolTypesArrays[0][0][3] = t15;
            toolColletion.count++;
            toolColletion.ToolTypesArrays[0][0][4] = t16;
            toolColletion.count++;
            toolColletion.ToolTypesArrays[0][0][5] = t17;
            toolColletion.count++;

            toolColletion.ToolTypesArrays[1][1][0] = t18;
            toolColletion.count++;
            toolColletion.ToolTypesArrays[1][1][1] = t19;
            toolColletion.count++;

            toolColletion.ToolTypesArrays[7][0][0] = t20;
            toolColletion.count++;
            toolColletion.ToolTypesArrays[7][0][1] = t21;
            toolColletion.count++;


            toolColletion.ToolTypesArrays[8][0][0] = t22;
            toolColletion.count++;
            toolColletion.ToolTypesArrays[8][0][1] = t23;
            toolColletion.count++;




            MainMenu.DisplayMenu(memberCollection,toolColletion);
           


            
    }
}
}
