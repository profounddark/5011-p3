class DataCut : DataFilter
{
    /// <summary>
    /// The sequence that was previously scrambled.
    /// </summary>
    private int[] _previousSequence = new int[0];

    /// <summary>
    /// findMinIndex finds the index of the minimum
    /// value in the provided integer array.
    /// </summary>
    /// <param name="searchArray">an array of integers
    /// to search</param>
    /// <returns>the index of the minimum value</returns>
    private int _findMinIndex(int[] searchArray)
    {

        int minIndex = 0;

        for (int i = 0; i < searchArray.Length; i++)
        {
            if (searchArray[i] < searchArray[minIndex])
            {
                minIndex = i;
            }
        }

        return minIndex;
    }

    /// <summary>
    /// findMaxIndex finds the index of the maximum
    /// value in the provided integer array.
    /// </summary>
    /// <param name="searchArray">an array of integers
    /// to search</param>
    /// <returns>the index of the maximum value</returns>
    private int _findMaxIndex(int[] searchArray)
    {
        int maxIndex = 0;

        for (int i = 0; i < searchArray.Length; i++)
        {
            if (searchArray[i] < searchArray[maxIndex])
            {
                maxIndex = i;
            }
        }

        return maxIndex;
    }

    public DataCut(uint newPrime = DefaultPrimeNumber) : base(newPrime) { }

    /// <summary>
    /// filter() returns an array of values depending on the state of the DataCut
    /// object. If no data sequence has been set, it returns an array of Length 0.
    /// Otherwise, it returns a subsequence of the data sequence depending on the
    /// state of the object, Large or Small.
    /// If the state is Large, the subsequence contains only integers which are
    /// greater than the encapsulated prime number (minus the largest integer).
    /// If the state is Small, the subsequence contains only integers which are
    /// less than the encapsulated prime number (minus the smallest integer).
    /// Note: This can result in an integer array of Length 0.
    /// </summary>
    /// <returns>an integer array of values that depend on the state of the
    /// DataCut object.</returns>
    public override int[] filter()
    {
        int[] processArray = base.filter();

        int removeIndex;
        if (_currentState == FilterState.Large)
        {
            removeIndex = _findMaxIndex(processArray);
        }
        else
        {
            removeIndex = _findMinIndex(processArray);
        }

        /// Output array for copying processArray
        int[] outputArray = new int[processArray.Length - 1];

        /// counter for the new array
        int newCount = 0;

        for (int i = 0; i < processArray.Length; i++)
        {
            if (i != removeIndex)
            {
                outputArray[newCount] = processArray[i];
                newCount++;
            }
        }

        return outputArray;
    }

    public override int[]? scramble(int[]? newSequence = null)
    {
        if (newSequence == null)
        {
            newSequence = _dataSequence;
        }

        for (int i = 0; i < newSequence.Length; i++)
        {
            for (int j = 0; j < _previousSequence.Length; j++)
            {

            }
        }

        // do stuff
        // I have not done stuff yet

        newSequence = base.scramble(newSequence);

        _previousSequence = newSequence;

        return newSequence;

    }


}