using System;

namespace IT481_RebeccaDeLaney_Unit6
{
    class Customer
    {
        int NumItems;

        public Customer()
        {
            NumItems = 6;
        }

        public Customer(int items)
        {
            int ClothingItems = items;

            if (ClothingItems == 0)
            {
                NumItems = GetRandomNumber(1, 20);
            } else
            {
                NumItems = ClothingItems;
            }
        }

        //Return the number of items
        public int getNumberOfItems()
        {
            return NumItems;    
        }
         //Random number method
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
