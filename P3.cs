// See https://aka.ms/new-console-template for more information

class P3
{
    public static void TestFilter(DataFilter testObj)
    {
        Console.Write("testing filter(): ");
        int[] filterOutput = testObj.filter();
        for (int i = 0; i < filterOutput.Length; i++)
        {
            Console.Write(filterOutput[i] + " ");

        }
        Console.Write("\n");
        Console.WriteLine("Testing complete");
    }
    public static void Main(String[] args)
    {
        DataFilter testFilter = new DataFilter(89);

        TestFilter(testFilter);


        testFilter.scramble(new int[] { 100, 90, 60, 70, 50, 120 });
        TestFilter(testFilter);
        testFilter.FlipState();
        TestFilter(testFilter);

        testFilter.scramble();
        TestFilter(testFilter);
        testFilter.FlipState();
        TestFilter(testFilter);

        DataMod testMod = new DataMod(89);
        testMod.scramble(new int[] { 90, 61, 13, 71, 83, 120 });
        testMod.FlipState();
        testMod.filter();
        TestFilter(testMod);









    }
}

