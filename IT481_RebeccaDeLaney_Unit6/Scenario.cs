using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IT481_RebeccaDeLaney_Unit6
{
    class Scenario
    {
        static Customer cus;
        static int items = 0;
        static int numItems;
        static int controlItemNum;

        public Scenario(int r, int c)
        {
            Console.WriteLine(r + " dressing rooms " + " for " + c + " customers.");

            controlItemNum = 0;
            numItems = 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("How many items will each customer try on? (0 = random)");
            controlItemNum = Int32.Parse(Console.ReadLine());

            Console.WriteLine("How many customers are there?");
            int numCustomers = Int32.Parse(Console.ReadLine());
            Console.WriteLine("There are " + numCustomers + " total customers.");

            Console.WriteLine("How many dressing rooms are there?");
            int totalRooms = Int32.Parse(Console.ReadLine());

            Scenario s = new Scenario(totalRooms, numCustomers);

            DressingRooms dr = new DressingRooms(totalRooms);

            List<Task> tasks = new List<Task>();

            for (int i = 0; i < numCustomers; i++)
            {
                cus = new Customer(controlItemNum);
                numItems = cus.getNumberOfItems();
                items += numItems;
                tasks.Add(Task.Factory.StartNew(async () => { 
                    await dr.RequestRoom(cus); 
                }));
            }

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("Average Run time in milliseconds {0} ", dr.getRunTime() / numCustomers);
            Console.WriteLine("Average Wait time in milliseconds {0} ", dr.getWaitTime() / numCustomers);
            Console.WriteLine("Total number of customers is {0}", numCustomers);
            int aveItemsPerCus = items / numCustomers;
            Console.WriteLine("Average number of items was: " + aveItemsPerCus);
            Console.Read();
        }
    }
}
