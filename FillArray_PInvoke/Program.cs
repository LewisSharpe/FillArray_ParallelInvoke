using System;
using System.Threading.Tasks;

class Program
{
    static int counter;

    // main starts Parallel.Invoke over processor count
    static void Main(string[] args)
    {
        FillArray_PInvoke.CustomStopwatch watch = new FillArray_PInvoke.CustomStopwatch();
        int num = 0; int result = 0;
        counter = 0;
        for (int i = 0; i < Environment.ProcessorCount; i++)
        {
            watch.Start();
            Parallel.Invoke(
            () => func(i)); // Parallel invoke array filled with tasks in func
            watch.Stop();
            Console.Write("Invoking.........");
            Console.WriteLine("#### THREAD " + i + " - StartAt: {0}, EndAt: {1}", watch.StartAt.Value, watch.EndAt.Value); // timestamp to identify level of thread distribution representation
            Console.WriteLine(generateRandomsforSearch(result, num));
        }

        Console.Read();
    }
    // Method performs a Linear Search
    public static int search(int[] arr, int x)
    {
        int n = arr.Length;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] == x)
                return i;
        }
        return -1;
    }
   // method generates randoms for search and begin search
    static int generateRandomsforSearch(int result, int num)
    {
        int Min = 0;
        int Max = 500000; // set max items to 500,000
                          // this declares an integer array with 5 elements
                          // and initializes all of them to their default value
                          // which is zero

        Random rnd = new Random();
        int x = rnd.Next(1, 500000);  // generate a random number between 1 and 500,000
        Console.Write(Environment.NewLine + "##### The number selected: " + x + Environment.NewLine);
        int[] arr = new int[5000]; // generate list of 5000 entries between 0 and 500,000
        Random randNum = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = randNum.Next(Min, Max); // fill list with 5,000 random entries between 0 and 500,000
            Console.Write("{0}  ", arr[i]); 
        }
        Console.Write(Environment.NewLine + "##### The number selected: " + x + Environment.NewLine);
        result = search(arr, x); // set result to result of the linear search
        // is the selected number in the list?
        if (result == -1)
            Console.WriteLine(Environment.NewLine + "#### Element is not present in array"); // found in list
        else
            Console.WriteLine(Environment.NewLine + "#### Element is present at index " + result); // not found in list

        return result;
}
    // Method fills arrays with tasks ready to Parallel.Invoke in main
    static void func(int num)
    {
        var actions = new Action[Environment.ProcessorCount];

        Console.Write("Filling array.........");
        for (int i = 0; i < Environment.ProcessorCount; i++)
        {
            // Console.WriteLine(string.Format("This is function #{0} loop. counter - {1}", num, counter));
            actions[i] = () => func(num);
            counter++;
        }
      
    }
}