// See https://aka.ms/new-console-template for more information

class P3
{

    const int TestSize = 10;

    /// <summary>
    /// TestFilter tests a DataFilter object's filter() method.
    /// </summary>
    /// <param name="testObj">the DataFilter object (or child object)
    /// to test</param>
    public static void TestFilter(DataFilter testObj)
    {
        Console.Write("testing filter(): ");
        int[] filterOutput = testObj.filter();
        if (filterOutput.Length != 0)
        {
            for (int i = 0; i < filterOutput.Length; i++)
            {
                Console.Write(filterOutput[i] + " ");

            }
            Console.Write("\n");
        }
        else
        {
            Console.WriteLine("No output from filter.");
        }

        Console.WriteLine("Testing complete");
    }

    /// <summary>
    /// TestScramble tests a DataFilter object's scramble method
    /// </summary>
    /// <param name="testObj">the DataFilter object (or child object)
    /// to test</param>
    public static void TestScramble(DataFilter testObj)
    {
        Console.Write("testing scramble(): ");
        int[] scrambleOutput = testObj.scramble();
        if (scrambleOutput.Length != 0)
        {
            for (int i = 0; i < scrambleOutput.Length; i++)
            {
                Console.Write(scrambleOutput[i] + " ");

            }
            Console.Write("\n");
        }
        else
        {
            Console.WriteLine("No output from scramble.");
        }

        Console.WriteLine("Testing complete");
    }

    /// <summary>
    /// TestScramble tests a DataFilter object's scramble method
    /// </summary>
    /// <param name="testObj">the DataFilter object (or child object)
    /// to test</param>
    /// <param name="testArray">the test array to pass to the scramble
    /// method</param>
    public static void TestScrambleArray(DataFilter testObj, int[] testArray)
    {
        Console.Write("testing scramble(): ");
        int[] scrambleOutput = testObj.scramble(testArray);
        if (scrambleOutput.Length != 0)
        {
            for (int i = 0; i < scrambleOutput.Length; i++)
            {
                Console.Write(scrambleOutput[i] + " ");

            }
            Console.Write("\n");
        }
        else
        {
            Console.WriteLine("No output from scramble.");
        }

        Console.WriteLine("Testing complete");
    }



    /// <summary>
    /// CreateHeteroCollection makes a heterogenous collection of DataFilter objects
    /// for testing.
    /// </summary>
    /// <param name="size">size of the array, defaults to TestSize</param>
    /// <param name="offset">an offset, used to mix up the array!</param>
    /// <returns></returns>
    public static DataFilter[] CreateHeteroCollection(int size = TestSize, int offset = 0)
    {
        DataFilter[] filterArray = new DataFilter[TestSize];

        for (int i = offset; i < filterArray.Length + offset; i++)
        {
            if (i % 3 == 2)
            {
                filterArray[i - offset] = new DataCut((uint)i * 15);
            }
            else if (i % 3 == 1)
            {
                filterArray[i - offset] = new DataMod((uint)i * 10);
            }
            else
            {
                filterArray[i - offset] = new DataFilter((uint)(i * 20));
            }
        }

        return filterArray;
    }

    public static void HeteroTest(int size)
    {
        int[] TestArray = { 10, 20, 35, 100, 51, 150, 19, 200, 95, 300, 125, 89, 111, 273 };

        Console.WriteLine("Creating a hetereogenous collection of size " + size + " for testing:");
        DataFilter[] filterArray = CreateHeteroCollection(size, 2);

        Console.WriteLine("Embedding integer sequences.");
        for (int i = 0; i < size; i++)
        {
            int[] newArray = new int[TestArray.Length];
            TestArray.CopyTo(newArray, 0);
            filterArray[i].SetSequence(TestArray);
        }
        Console.WriteLine("Testing filters:");
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine("Testing Filter on object #" + i + ":");
            TestFilter(filterArray[i]);
            Console.WriteLine("Flipping state...");
            filterArray[i].FlipState();
            TestFilter(filterArray[i]);
            Console.Write("\n");
        }





    }

    public static void Main(String[] args)
    {

        HeteroTest(10);
    }
}

