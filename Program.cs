using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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


        //Async and Await
       Worker workerObj = new Worker();
        workerObj.work();
        


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
   
public class Worker{
    public Worker(){
       // work();
    }
    public void work(){
        AsyncClass asc= new AsyncClass();
        asc.work();
        Console.WriteLine("I'm on main Thread");
       for (int i=0;i<10000;i++){
            Console.Write(".");
        }
        
        Console.WriteLine("Main Thred Completed");
    }
}

public class AsyncClass{
    /*public async void work(){
        await SlowTask();
        Console.WriteLine("End Work");
    }*/
     public async void work(){
         await SlowTask();
        Console.WriteLine("End Work");
    }

    public async Task SlowTask(){
        for(int i=0;i<50;i++){
            Console.WriteLine(i);
            for(int j=0;j<10000;j++){
                var k = Math.Sqrt(j);
            }
        }
        Console.WriteLine("Done");
    }
}

}
