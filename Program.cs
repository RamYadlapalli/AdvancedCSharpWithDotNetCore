using System;
using System.Collections.Generic;

namespace CSharpApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //string interpolation c#6.0
            int num=6;
            double floatingNum =22.3;
            string stringVar = "I am string";
            Console.WriteLine($"Printing values using string manipulation Int {num}, float as String {Convert.ToString(floatingNum)}, string {stringVar}");
         
         //Null Conditional Operator --> Return null if property not exist 
         List <string> employees = null;//new List<string>();
        /* Console.WriteLine("Code breaks in below line as employees.Count retuns undefined");
         int? count = employees.Count;
         */
         //Below statement doesn't break and assign null value to count
         int? count = employees?.Count;
         string result = count == null?"Count is null":"Count is not null";
         Console.WriteLine($"Result {result}");

         //Null Coalescing --> Return a value if statement evalutes to null
         int mainCount = employees?.Count ?? 0;
         //mainCount is set to 0 not to null 
         Console.WriteLine($"Value of main count is {mainCount}");


        //Using ReadOnly Properties
        vehicle car=new vehicle();
        car.Name="Indica";
       // car.Type="auto"; --Throws error as it is ReadOnly Property

        }
    }
    public class vehicle{
       //ReadOnly properties 
        public string Type{get;}="Vehicle";
        //Read and Write Property values
        public string Name{get;set;}
        //Private --fields 
        private int wheels =2; 
    }
   
}
