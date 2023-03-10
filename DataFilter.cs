/// <summary>
/// The DataFilter class creates a mysterious object with two principal
/// methods: filter and scramble. The object encapsulates a prime number,
/// specified at instantiation, that provides mysterious insight to the
/// class.
/// 
/// The class utilizes an Array of integers as a data sequence. This sequence
/// is used by the main methods, filter and scramble, to create new
/// Arrays of integers. The Array is "loaded" into the class via one of
/// two methods: the SetSequence method (which sets the sequence with
/// no other action); and the scramble method. The scramble method sets
/// the new sequence (if provided) and then creates a scramble based
/// on the encapsulated sequence.
/// 
/// The class maintains a state of Large or Small, which dictates certain
/// behaviors in the filter and scramble methods. This state starts as
/// Large and can be changed via the FlipState method.
/// </summary>
class DataFilter
{

    /// <summary>
    /// A enum for tracking the state of a DataFilter object. Consists
    /// of two states: Large or Small.
    /// </summary>
    protected enum FilterState
    {
        Large,
        Small
    }

    /// <summary>
    /// The default prime number for instancing a new DataFilter object.
    /// </summary>
    protected const uint DefaultPrimeNumber = 97;

    protected uint _primeNumber;
    protected int[] _dataSequence;

    protected FilterState _currentState;


    /// <summary>
    /// isPrime determines whether or not the given positive integer is a prime number
    /// or not (i.e., a whole number greater than one that cannot be exactly divided by
    /// any whole number other than itself)
    /// </summary>
    /// <param name="testNumber">the positive integer to be tested</param>
    /// <returns><c>true</c> if the number is prime, <c>false</c> otherwise</returns>
    protected bool _isPrime(uint testNumber)
    {
        for (uint i = 2; i < testNumber; i++)
        {
            if (testNumber % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Constructor for DataFilter object. Accepts a positive prime integer as the
    /// encapsulated prime number. If the integer is not provided, falls back
    /// to a default value.
    /// </summary>
    /// <param name="newPrime">A positive, prime integer to encapsulate in the
    /// DataFilter object.</param>
    public DataFilter(uint newPrime = DefaultPrimeNumber)
    {
        // try to set teh new prime to teh provided value
        if (!SetPrime(newPrime))
        {
            // if it failed, set to the Default
            _primeNumber = DefaultPrimeNumber;
        }

        // "null" value for sequence is an empty array
        // NOTE: an array is a non-nullable reference type so this program
        // uses empty Arrays to represent no value assigned.
        _dataSequence = Array.Empty<int>();

        // set to a State of "Large"
        _currentState = FilterState.Large;


    }


    /// <summary>
    /// SetPrime sets the encapsulated prime for the DataFilter object.
    /// </summary>
    /// <param name="newPrime">a new positive prime number to set as the encapsulated
    /// prime number.</param>
    /// <returns>true if the new prime was set successfully. false otherwise</returns>
    public bool SetPrime(uint newPrime)
    {
        if (_isPrime(newPrime))
        {
            _primeNumber = newPrime;
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// SetSequence sets the data sequence for the DataFilter object.
    /// </summary>
    /// <param name="newSequence">the new integer sequence to set. This cannot
    /// be null (as the array is a non-nullable reference type), but it can
    /// be an Empty Array.</param>
    public void SetSequence(int[] newSequence)
    {
        _dataSequence = newSequence;
    }

    /// <summary>
    /// FlipState flips the state of the current DataFilter. If it is in
    /// the Large state, it changes to Small state. If it is in Small state,
    /// it changes to Large state.
    /// </summary>
    public void FlipState()
    {
        if (_currentState == FilterState.Large)
        {
            _currentState = FilterState.Small;
        }
        else
        {
            _currentState = FilterState.Large;
        }
    }

    /// <summary>
    /// filter() returns an array of values depending on the state of the DataFilter
    /// object. If no data sequence has been set, it returns an array of size 1 that
    /// contains the encapsulated prime number. Otherwise, it returns a subsequence
    /// of the data sequence depending on the state of the object, Large or Small.
    /// If the state is Large, the subsequence contains only integers which are
    /// greater than the encapsulated prime number. If the state is Small, the
    /// subsequence contains only integers which are less than the encapsulated
    /// prime number.
    /// </summary>
    /// <returns>an integer array of values that depend on the state of the
    /// DataFilter object.</returns>
    public virtual int[] filter()
    {
        // does not have an embedded sequence
        if (_dataSequence.Length == 0)
        {
            int[] returnArray = new int[1];
            returnArray[0] = (int)_primeNumber;
            return returnArray;
        }

        // if it has an embedded sequence
        else
        {
            int[] returnArray = new int[_dataSequence.Length];
            int itemCount = 0;
            for (int i = 0; i < _dataSequence.Length; i++)
            {
                switch (_currentState)
                {
                    case FilterState.Large:
                        // only add greater than items
                        if (_dataSequence[i] > _primeNumber)
                        {
                            returnArray[itemCount] = _dataSequence[i];
                            itemCount++;
                        }
                        break;
                    case FilterState.Small:
                        // only add less than items
                        if (_dataSequence[i] < _primeNumber)
                        {
                            returnArray[itemCount] = _dataSequence[i];
                            itemCount++;
                        }
                        break;
                }

            }

            // gets rid of the empty part of the array
            Array.Resize(ref returnArray, itemCount);

            return returnArray;
        }


    }

    /// <summary>
    /// scramble proceeds to create a scramble of the values in the
    /// DataFilter object based on the current state of the object.
    /// </summary>
    /// <returns>the scrambled sequence. If the DataFilter object had
    /// no encapsulated sequence, returns an empty array.</returns>
    public virtual int[] scramble()
    {

        int[] newSequence = new int[_dataSequence.Length];
        _dataSequence.CopyTo(newSequence, 0);

        for (int i = 0; i < newSequence.Length / 2; i++)
        {
            int highIndex = newSequence.Length - i - 1;
            // find difference between pairs
            int pairDiff = (newSequence[highIndex] - newSequence[i]);

            // flip sign if set to Large
            if (_currentState == FilterState.Small)
            {
                pairDiff = -pairDiff;
            }

            // swap if the diff is greater than 0
            if (pairDiff > 0)
            {
                int temp = newSequence[i];
                newSequence[i] = newSequence[highIndex];
                newSequence[highIndex] = temp;
            }
        }

        return newSequence;

    }

    /// <summary>
    /// scramble assigns a new sequence to the DataFilter object. It then proceeds
    /// to create a scramble of the values in the DataFilter object based on the
    /// current state of the object.
    /// </summary>
    /// <param name="newSequence">a new integer array to assign to the DataFilter
    /// object</param>
    /// <returns>the reordered array of values encapsulated by the DataFilter
    /// object after being processed by the scrambler. If the DataFilter object had
    /// no encapsulated sequence, returns an empty array.</returns>
    public virtual int[] scramble(int[] newSequence)
    {
        // set the encapsulated sequence to the provided
        _dataSequence = newSequence;

        return this.scramble();

    }



}