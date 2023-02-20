class DataMod : DataFilter
{
    const int OverrideValue = 2;

    public DataMod(uint newPrime = DefaultPrimeNumber) : base(newPrime) { }


    /// <summary>
    /// filter() returns an array of values depending on the state of the DataMod
    /// object. If no data sequence has been set, it returns an array of size 1 that
    /// contains the encapsulated prime number. Otherwise, it returns a subsequence
    /// of the data sequence depending on the state of the object, Large or Small.
    /// If the state is Large, the subsequence contains only integers which are
    /// greater than the encapsulated prime number and each is incremented by 1.
    /// If the state is Small, the subsequence contains only integers which are
    /// less than the encapsulated prime number, each one decremented by 1.
    /// </summary>
    /// <returns>an integer array of values that depend on the state of the
    /// DataMod object.</returns>
    public override int[] filter()
    {
        int[] outputArray = base.filter();

        int modifier = (_currentState == FilterState.Large) ? 1 : -1;

        for (int i = 0; i < outputArray.Length; i++)
        {
            outputArray[i] = outputArray[i] + modifier;
        }
        return outputArray;
    }


    public override void scramble(int[]? newSequence = null)
    {
        // if no new sequence
        if (newSequence == null)
        {
            // use the existing sequence
            newSequence = _dataSequence;
        }

        // if there is a sequence
        if (newSequence != null)
        {
            for (int i = 0; i < newSequence.Length; i++)
            {
                // replace prime numbers with the Override Value
                if ((newSequence[i] > 0) &&
                    (_isPrime((uint)newSequence[i])))
                {
                    newSequence[i] = OverrideValue;
                }
            }
        }
        // run original scrambler
        base.scramble(newSequence);
    }
}