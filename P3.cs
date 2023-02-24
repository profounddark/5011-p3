// See https://aka.ms/new-console-template for more information

class P3
{

    const int TestSize = 10;

    /// <summary>
    /// TestFilter tests a DataFilter object's filter() method.
    /// </summary>
    /// <param name="testObj">the DataFilter object (or child object)
    /// to test</param>
    public static void TestFilter(DataFilter testObj, string expectedOutput = "")
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
        if (expectedOutput != "")
        {
            Console.WriteLine("Expected output: " + expectedOutput);
        }

        Console.WriteLine("Testing complete");
    }

    /// <summary>
    /// TestScramble tests a DataFilter object's scramble method
    /// </summary>
    /// <param name="testObj">the DataFilter object (or child object)
    /// to test</param>
    public static void TestScramble(DataFilter testObj, string expectedOutput = "")
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
        if (expectedOutput != "")
        {
            Console.WriteLine("Expected output: " + expectedOutput);
        }

        Console.WriteLine("Testing complete");
    }

    /// <summary>
    /// TestFilterObject tests the DataFilter class.
    /// </summary>
    public static void TestFilterObject()
    {
        uint InitialValue = 101;
        int[] InitialArray = { 57, 69, 105 };

        Console.WriteLine("Testing DataFilter Object using initial value " + InitialValue);
        DataFilter testObject = new DataFilter(InitialValue);
        Console.WriteLine("Injecting dependency array: " + string.Join(" ", InitialArray));
        testObject.SetSequence(InitialArray);
        TestFilter(testObject, "105");
        TestScramble(testObject, "105 69 57");
        Console.WriteLine("Fliiping state...");
        testObject.FlipState();
        TestFilter(testObject, "57 69");
        TestScramble(testObject, "57 69 105");
        Console.WriteLine("testing of DataFilter complete!\n");
    }

    /// <summary>
    /// TestModObject tests the DataMod class.
    /// </summary>
    public static void TestModObject()
    {
        uint InitialValue = 53;
        int[] InitialArray = { 35, 47, 17, 63, 91 };

        Console.WriteLine("Testing DataMod Object using initial value " + InitialValue);
        DataMod testObject = new DataMod(InitialValue);
        Console.WriteLine("Injecting dependency array: " + string.Join(" ", InitialArray));
        testObject.SetSequence(InitialArray);
        TestFilter(testObject, "64 92");
        TestScramble(testObject, "91 63 2 2 35");
        Console.WriteLine("Fliiping state...");
        testObject.FlipState();
        TestFilter(testObject, "34 1 1 62 90");
        TestScramble(testObject, "35 2 2 63 91");
        Console.WriteLine("testing of DataMod complete!\n");

    }

    public static void TestCutObject()
    {
        uint InitialValue = 53;
        int[] InitialArray = { 35, 140, 47, 17, 63, 91, 117 };

        Console.WriteLine("Testing DataCut Object using initial value " + InitialValue);
        DataCut testObject = new DataCut(InitialValue);
        Console.WriteLine("Injecting dependency array: " + string.Join(" ", InitialArray));
        testObject.SetSequence(InitialArray);
        TestFilter(testObject, "140 91 117");
        TestScramble(testObject, "117 140 63 17 47 91 35");
        Console.WriteLine("Fliiping state...");
        testObject.FlipState();
        TestFilter(testObject, "35 47");
        TestScramble(testObject, "no output");
        Console.WriteLine("testing of DataCut complete!\n");
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

    /// <summary>
    /// HeteroTest instances a heterogenous array of DataFilter, DataMod, and DataCut
    /// objects and proceeds to conducts various tests on that collection.
    /// </summary>
    /// <param name="size">the number of items to test in the heterogenous array</param>
    public static void HeteroTest(int size)
    {
        int[] TestArray = { 10, 20, 35, 100, 51, 150, 19, 200, 95, 300, 125, 89, 111, 273 };
        int[] SupplementalArray = { 25, 63, 79, 150, 47, 273, 100, 10, 129, 300, 139 };

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

        Console.WriteLine("Testing scrambles:");
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine("Testing Scramble on object #" + i + ":");
            TestScramble(filterArray[i]);
            Console.WriteLine("Flipping state and providing supplemental sequence...");
            filterArray[i].FlipState();
            TestScrambleArray(filterArray[i], SupplementalArray);
            Console.Write("\n");
        }

        Console.WriteLine("Tests complete on all objects.");

    }

    public static void Main(String[] args)
    {
        TestFilterObject();
        Console.WriteLine("* * * * * * * * * *\n");
        TestModObject();
        Console.WriteLine("* * * * * * * * * *\n");
        TestCutObject();
        Console.WriteLine("* * * * * * * * * *\n");

        HeteroTest(10);
    }
}

