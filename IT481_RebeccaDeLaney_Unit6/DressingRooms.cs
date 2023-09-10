using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IT481_RebeccaDeLaney_Unit6
{
       
    class DressingRooms
    {
        int rooms;
        Semaphore sem;
        long waitTimer;
        long runTimer;

        public DressingRooms()
        {
            rooms = 3;
            sem = new Semaphore(rooms, rooms);
        }

        public DressingRooms(int r)
        {
            rooms = r;
            sem = new Semaphore(rooms, rooms);
        }

        public async Task RequestRoom(Customer c)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Customer is waiting.");

            sw.Start(); 
            sem.WaitOne();
            sw.Stop();
            waitTimer += sw.ElapsedTicks;

            int roomWaitTime = GetRandomNumber(1, 3);
            sw.Start();
            Thread.Sleep((roomWaitTime*c.getNumberOfItems()));
            sw.Stop();
            runTimer += sw.ElapsedTicks;
            Console.WriteLine("Customer finished trying on item in room");
            sem.Release();
        }
        public long getWaitTime()
        {
            return waitTimer;
        }

        public long getRunTime()
        {
            return runTimer;
        }


        private static readonly Random getRandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            lock (getRandom)
            {
                return getRandom.Next(min, max);
            }
        }
    }
}
