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
        DataFilter testFilter = new DataCut(89);

        TestFilter(testFilter);


        testFilter.scramble(new int[] { 100, 60, 70, 110 });

        TestFilter(testFilter);










    }
}

