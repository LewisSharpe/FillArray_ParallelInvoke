using System;
using System.Threading.Tasks;

class Program
{
    static int counter;
    public static FillArray_PInvoke.CustomStopwatch watch = new FillArray_PInvoke.CustomStopwatch();
    // main starts Parallel.Invoke over processor count
    int num = Environment.ProcessorCount;
    static void Main(string[] args)
    {
        Action[] action;
        int num = 0; int result = 0;
        counter = 0;
            action = Func();
            Parallel.Invoke(action); // Parallel invoke array filled with tasks in func          
        Console.Read();
    }
    // Method performs a Linear Search
    public static int search(int[] arr, int x)
    {
        watch.Start(); // starts timer for search
        int n = arr.Length;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] == x)
                return i;
        }
        watch.Stop(); // stops timer for search, time displayed in main
        Console.WriteLine("#### THREAD " + Environment.ProcessorCount + " - StartAt: {0}, EndAt: {1}", watch.StartAt.Value, watch.EndAt.Value); // timestamp to identify level of thread distribution representation
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
        Console.Write(Environment.NewLine + "THREAD" + num + "##### The number selected: " + x + Environment.NewLine);
        int[] arr = new int[5000000]; // generate list of 5000 entries between 0 and 500,000
        Random randNum = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = randNum.Next(Min, Max); // fill list with 5,000 random entries between 0 and 500,000
     //       Console.Write("{0}  ", arr[i]); 
        }
        result = search(arr, x); // set result to result of the linear search
        // is the selected number in the list?
        if (result == -1)
            Console.WriteLine(Environment.NewLine + "THREAD" + num + "#### Element is not present in array"); // found in list
        else
            Console.WriteLine(Environment.NewLine + "THREAD" + num + "#### Element is present at index " + result); // not found in list

        return result;
}
    // Method fills arrays with tasks ready to Parallel.Invoke in main
   static Action[] Func()
    {
        int num = 0;
        int result = 0;
        var actions = new Action[Environment.ProcessorCount];
        for (int i = 0; i < Environment.ProcessorCount; i++)
        {
            // Console.WriteLine(string.Format("This is function #{0} loop. counter - {1}", num, counter));
            actions[i] = () => generateRandomsforSearch(result, i);
            counter++;
        }
        return actions;
    }
}