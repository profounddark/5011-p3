// See https://aka.ms/new-console-template for more information

class P3
{
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


    public static void Main(String[] args)
    {
        DataMod testFilter = new DataMod(89);

        TestFilter(testFilter);
        TestScramble(testFilter);
        TestScrambleArray(testFilter, new int[] { 109, 70, 67, 100 });

        TestFilter(testFilter);

        testFilter.FlipState();
        TestScrambleArray(testFilter, new int[] { 109, 70, 67, 105 });




    }
}

