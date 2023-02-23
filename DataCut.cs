/// <summary>
/// The DataCut class is a derived class from the DataFilter class. Although it
/// replicates the structure of the original class, two of the significant
/// methods of the class have changed: filter and scramble.
/// 
/// The filter method replicates the function of the DataFilter method but
/// removes a single value from the resulting array depending on the state
/// of the DataCut object.
/// 
/// The scramble method replicates the function of the DataFilter method
/// but, prior to scrambling, removes all elements from the encapsulated
/// sequence that were in the previous output of the scramble method.
/// </summary>
class DataCut : DataFilter
{
    /// <summary>
    /// The sequence that was previously scrambled.
    /// </summary>
    private int[] _previousSequence;

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

    /// <summary>
    /// Constructor for DataCut object. Accepts a positive prime integer as the
    /// encapsulated prime number. If the integer is not provided, falls back
    /// to a default value.
    /// </summary>
    /// <param name="newPrime">A positive, prime integer to encapsulate in the
    /// DataFilter object.</param>
    public DataCut(uint newPrime = DefaultPrimeNumber) : base(newPrime)
    {
        // set previous search array to empty
        _previousSequence = Array.Empty<int>();
    }

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

    /// <summary>
    /// scramble clears the sequence encapsulated in the DataCut object of any
    /// values that appeared in the last scramble output. It then proceeds
    /// to create a scramble of the remaining values in the DataCut object
    /// based on the current state of the object.
    /// </summary>
    /// <returns>the scrambled sequence. If the DataCut object had
    /// no encapsulated sequence, returns an empty array.</returns>
    public override int[] scramble()
    {
        if (_dataSequence.Length != 0)
        {
            int[] newSequence = new int[_dataSequence.Length];
            int newCount = 0;

            for (int i = 0; i < _dataSequence.Length; i++)
            {
                // if the current value is not in the previous sequence
                if (Array.IndexOf(_previousSequence, _dataSequence[i]) < 0)
                {
                    // add it to the "new" sequence
                    newSequence[newCount] = _dataSequence[i];
                    newCount++;
                }
            }
            // shrink the new array
            Array.Resize(ref newSequence, newCount);

            _dataSequence = newSequence;
        }


        _previousSequence = base.scramble();
        return _previousSequence;

    }
}

