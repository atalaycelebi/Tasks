using System;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter the integer to be looked for");
            int[] array = { 0, 1, 123, 34, 67 };
            //if (typeof(Console.ReadLine)
            int x;
            try
            {
                x = int.Parse(Console.ReadLine());
                if (BinarySearchI(array, x) == -1)
                    Console.WriteLine("Value you entered does not exist int the array");
                else
                    Console.WriteLine("Value " + x + " exist int the array");
                Console.ReadLine();

                if (BinarySearchR(array, 0, array.Length-1, x) == -1)
                    Console.WriteLine("Value you entered does not exist int the array");
                else
                    Console.WriteLine("Value " + x + " exist int the array");
                Console.ReadLine();

            }
            catch
            {
                Console.WriteLine("Value you entered is not an integer");
                Console.ReadLine();
            }
            
        }

        // Returns index of value lookedfor with non-recursive algorithm
        public static int BinarySearchI(int[] array, int lookedfor)
        {
            int first = 0, last = array.Length - 1;
            while (first <= last)
            {
                int middle = first + (last - first) / 2;

                // Check if looked for is middle value
                if (array[middle] == lookedfor)
                    return middle;

                // If lookedfor greater, throw left side
                if (array[middle] < lookedfor)
                    first = middle + 1;

                // If lookedfor smaller, throw right side
                else
                    last = middle - 1;
            }

            // there is no lookedfor value in the array
            return -1;
        }


        // Returns index of value lookedfor with recursive algorithm
        public static int BinarySearchR(int[] array, int first, int last, int lookedfor)
        {
            if (last >= first)
            {
                int middle = first + (last - first) / 2;

                // If the lookedfor value is the middle member
                if (array[middle] == lookedfor)
                    return middle;

                // If lookedfor is smaller than  middle one it can only be at the left part
                if (array[middle] > lookedfor)
                    return BinarySearchR(array, first, middle - 1, lookedfor);

                // If lookedfor is greater than  middle one it can only be at the right part
                return BinarySearchR(array, middle + 1, last, lookedfor);
            }

            // there is not looked for value in the array
            return -1;

        }



    }
}
