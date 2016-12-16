using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpApp
{
    //Delegate declaration
    public delegate int doOperation(int x, int y);
    //MultiCast Deligate 
    public delegate void doMultiCastDelegate(int x, int y);
    //Generic Delegates
    public delegate T doGenericDelegate<T>(T arg, T arg1);
    public class Program
    {
        //Delegates 
        private static int doSum(int x, int y)
        {
            return x + y;
        }
        private static int doEquation(int x, int y)
        {
            return x * x + y;
        }
        private static void doPrint(int x, int y)
        {
            Console.WriteLine($"In doPrint method X: {x}, y:{y}");
        }
        private static void doPrint2(int x, int y)
        {
            Console.WriteLine($"In doPrint2 method X: {x}, y:{y}");
        }
        public static void Main(string[] args)
        {
            Console.WriteLine(@"Select one of the below features to execute
            1. String Interpolation  
            2. Null Conditional Operator
            3. Null Coalescing
            4. Async and Await 
            5. Read Only Properties
            6. Singlecast Delegates
            7. Multicast Delegates
            8. Generic Delegates
            9. Exit
            ");
            try
            {

                int option = Int32.Parse(Console.ReadLine());
                List<string> employees = null;//new List<string>();
                switch (option)
                {
                    case 1:
                        //string interpolation c#6.0
                        int num = 6;
                        double floatingNum = 22.3;
                        string stringVar = "I am string";
                        Console.WriteLine($"Printing values using string manipulation Int {num}, float as String {Convert.ToString(floatingNum)}, string {stringVar}");
                        break;

                    case 2:
                        //Null Conditional Operator --> Return null if property not exist 
                        /* Console.WriteLine("Code breaks in below line as employees.Count retuns undefined");
                         int? count = employees.Count;
                          */
                        //Below statement doesn't break and assign null value to count

                        int? count = employees?.Count;
                        string result = count == null ? "Count is null" : "Count is not null";
                        Console.WriteLine($"Result {result}");
                        break;

                    case 3:
                        //Null Coalescing --> Return a value if statement evalutes to null
                        int mainCount = employees?.Count ?? 0;
                        //mainCount is set to 0 not to null 
                        Console.WriteLine($"Value of main count is {mainCount}");
                        break;

                    case 4:
                        //Async and Await
                        Worker workerObj = new Worker();
                        workerObj.work();
                        break;

                    case 5:
                        //Using ReadOnly Properties
                        vehicle car = new vehicle();
                        car.Name = "Indica";
                        // car.Type="auto"; --Throws error as it is ReadOnly Property     
                        break;

                    case 6:
                        //Delegates
                        //Intialize the delegate with function definition - SingleCast Delegates
                        doOperation doSingle = new doOperation(doSum);
                        int j = doSingle(4, 2);
                        Console.WriteLine($"Result with first delegate execution {j}");
                        doSingle = doEquation; //Short Hand for doSingle = new doSingle(doEquation);
                        int k = doSingle(4, 2);
                        Console.WriteLine($"Result with first delegate execution {k}");
                        break;

                    case 7:
                        //Multicast Delegates
                        doOperation doMulti = new doOperation(doSum);
                        doMulti += doEquation;
                        //As both of the above functions having return type, the last function will return 
                        Console.WriteLine(doMulti(4, 4));
                        //So multicast delegates should not have return types

                        // As we are casting multiple delegates they will execute sequentially
                        doMultiCastDelegate doMultiDel = doPrint;
                        doMultiDel += doPrint2;
                        doMultiDel(5, 6);

                        break;
                    case 8:
                        //Generic Delegates
                        Console.WriteLine("Assinging Generic values");
                        doGenericDelegate<int> doGenericDel = doSum;
                        doGenericDel(1, 2);
                        break;
                    default:
                        Console.WriteLine("Selected option not available");
                        break;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Input is in invalid format, exception details {ex.Message}");
            }
        }
    }
    public class vehicle
    {
        //ReadOnly properties 
        public string Type { get; } = "Vehicle";
        //Read and Write Property values
        public string Name { get; set; }
        //Private --fields 
        private int wheels = 2;
    }

    public class Worker
    {
        public Worker()
        {
            // work();
        }
        public void work()
        {
            AsyncClass asc = new AsyncClass();
            asc.work();
            Console.WriteLine("I'm on main Thread");
            /*for (int i=0;i<10000;i++){
                 Console.Write(".");
             }
             */
            Console.WriteLine("Main Thred Completed");
        }
    }

    public class AsyncClass
    {
        /*public async void work(){
            await SlowTask();
            Console.WriteLine("End Work");
        }*/
        public async void work()
        {
            await SlowTask();
            Console.WriteLine("End Work");
        }

        public async Task SlowTask()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(i);
                for (int j = 0; j < 10000; j++)
                {
                    var k = Math.Sqrt(j);
                }
            }
            Console.WriteLine("Done");
        }
    }

}
