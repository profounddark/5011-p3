class DataMod : DataFilter
{
    const int OverrideValue = 2;

    /// <summary>
    /// Constructor for DataMod object. Accepts a positive prime integer as the
    /// encapsulated prime number. If the integer is not provided, falls back
    /// to a default value.
    /// </summary>
    /// <param name="newPrime">the positive prime integer to be encapsulated
    /// by the DataMod object</param>
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

    /// <summary>
    /// scramble replaces any value in the encapsulated sequence
    /// that are prime numbers with a specified override value.
    /// It then creates a scramble of the values in the DataMod
    /// object based on the current state of the object.
    /// </summary>
    /// <returns>the scrambled sequence. If the DataFilter object had
    /// no encapsulated sequence, returns an empty array.</returns>
    public override int[] scramble()
    {
        // if there is a sequence
        if (_dataSequence.Length != 0)
        {
            for (int i = 0; i < _dataSequence.Length; i++)
            {
                // replace prime numbers with the Override Value
                if ((_dataSequence[i] > 0) &&
                    (_isPrime((uint)_dataSequence[i])))
                {
                    _dataSequence[i] = OverrideValue;
                }
            }
        }
        // run original scrambler
        return base.scramble();
    }
}