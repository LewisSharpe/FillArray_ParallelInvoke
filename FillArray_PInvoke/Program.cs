using System;
using System.Threading;
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
        // Console.Read();
    }

  // HWL: a really silly implementation of value-equality, just to generate more work
  private static bool ExpensiveEq(int m, int n) {
    for (int i = 0; i<=m; i++) {
      if (i==m && i==n)
	return true;
    }
    return m==n;
  }
    // Method performs a Linear Search
    public static int search(int[] arr, int x)
    {
	int found = -1;
        int n = arr.Length;
        watch.Start(); // starts timer for search
        for (int i = 0; i < n; i++)
        {
	  if (ExpensiveEq(arr[i], x))  // HWL: use expensive quality here to generate more work
	      {
		found = i;
		break; //return i;
	      }
        }
        watch.Stop(); // stops timer for search, time displayed in main
        Console.WriteLine("#### SUMMARY THREAD " + Thread.CurrentThread.ManagedThreadId + " - StartAt: {0}, EndAt: {1}", watch.StartAt.Value, watch.EndAt.Value); // timestamp to identify level of thread distribution representation
        return found;
    }
   // method generates randoms for search and begin search
  static int generateRandomsforSearch(Tuple<int,int> pair) // (int result, int num)
    {
        int result = pair.Item1;
        int num = pair.Item2;
        int Min = 0;
	int ArrLen = 20000; // HWL: tune this for more work
        int Max = 500000; // set max items to 500,000
                          // this declares an integer array with 5 elements
                          // and initializes all of them to their default value
                          // which is zero
	Thread thr = Thread.CurrentThread;;
	
        Random rnd = new Random();
        int x = rnd.Next(1, Max);  // generate a random number between 1 and 500,000
	// HWL: use thr.ManagedThreadId instead of num for thread id; can be used to provide different input to different threads; if so, keep input in a global datastructure, indexed by thr.ManagedThreadId
        Console.Write(Environment.NewLine + "+++++ BEGIN THREAD " + thr.ManagedThreadId + ": The number selected: " + x + Environment.NewLine);
        int[] arr = new int[ArrLen]; // generate list of 5000 entries between 0 and 500,000
        Random randNum = new Random();
        for (int j = 0; j < Environment.ProcessorCount; j++)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = randNum.Next(Min, Max); // fill list with 5,000 random entries between 0 and 500,000
                                                 //       Console.Write("{0}  ", arr[i]); 
            }
        }
        result = search(arr, x); // set result to result of the linear search
        // is the selected number in the list?
        if (result == -1)
            Console.WriteLine(Environment.NewLine + "----- END  THREAD " + thr.ManagedThreadId + ": is not present in array"); // found in list
        else
            Console.WriteLine(Environment.NewLine + "----- END  THREAD " + thr.ManagedThreadId + ": Element is present at index " + result); // not found in list

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

            actions[i] = () => generateRandomsforSearch(Tuple.Create(result, counter));
            counter++;
        }
        return actions;
    }
}
