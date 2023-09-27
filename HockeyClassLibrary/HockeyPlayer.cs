using Utils;

/// <summay>
/// An instance of this class will hold data about a hockey player.
/// </summay>

namespace HockeyClassLibrary.Data;
// ^^^ this is not actually necessary - just there to help us organize our namespaces and code
    // when we define a namespace, we are saying that all of the classes belong to this specific namespace

// class is like a blue print to instantiate an instance (the object)

// encapsulation - restricting access to the fields by making users use properties and methods
    // don't want to allow direct access to the fields so we mark the object as private
        // describes the object but not everyone can see
    // properties/methods are public because they are how people are going to be able to interact with the private fields if i want to show that at all.
    // private fields need to be kept in a valid state
        // if it's not private than an external entity could change it, if it's private than they can't
        // if an external entity wanted to change it, then they could use a property/method to change it then we could validate that info before changing the field.
        // public fields would mean that we're stripping away any encapsulation and someone could directly access it

// enums are essentially creating your own data type where you can assign a list of possible valid values that are listed
    // guarantees good valid values because you can only get values from the created list of values

// empty strings are still a string - they are not null
    // use a question mark at the end of string to say that you can have a null value (ex. private string? _birthPlace)

// An instance of this class will hold data about a hockey player 
public class HockeyPlayer
{
    // define data fields
        // the actual variables that holdsx the data that describes the class itself
        // field names are prefixed with an underscore and follow camel case naming conventions
        // auto-implemented properties can bypass the need for fields because fields will be created behind the scenes
    private string _birthPlace;
    private string _firstName;
    private string _lastName;
    private int _heightInInches;
    private int _weightInPounds;
    // use this instead of DateTime if you don't care for the time portion of that
    // 'using System' is where this comes from
    private DateOnly _dateOfBirth;
    private int _jerseyNumber;

    // properties
        // the idea behind properties is to give public access to fields
        // ways for us to retrieve or set data within the class without actually giving access to the field
        // have to have at least a 'get' which would be a read-only
        // fully-implemented - we defined the backing data store of where to store the data and manage it
        // auto-implemented - we just defined the property and we leave the data store up to the system
        // title-case naming conventions
    public string BirthPlace
    {
        get
        {
            // grabs the value that we want to access
            return _birthPlace;
        }

        private set // can only be utilized from within the class itself
        {
            // validation
                // always check for the exception first
            if (Utilities.IsNullEmptyOrWhiteSpace(value))
            {
                // throwing an exception will allow us to communicate this issue to whatever platform this system is being used for
                // Argument in ArgumentException refers to the value that was inputted
                // we're instantiated a new exception object
                throw new ArgumentException("Birth place cannot be null or empty.");
            }

            // does not need to be in an else because if the exception is thrown it excepts out of the property
            _birthPlace = value;
        }
    }

    public string FirstName
    {
        get
        {
            return _firstName;
        }

        private set
        {
            if (Utilities.IsNullEmptyOrWhiteSpace(value))
            {
                throw new ArgumentException("First Name cannot be null or empty.");
            }

            _firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return _lastName;
        }

        private set
        {
            if (Utilities.IsNullEmptyOrWhiteSpace(value))
            {
                throw new ArgumentException("Last Name cannot be null or empty.");
            }

            _lastName = value;
        }
    }

    public int HeightInInches
    {
        get
        {
            return _heightInInches;
        }

        private set
        {
            if (Utilities.IsZeroOrNegative(value))
            {
                throw new ArgumentException("Height must be positive.");
            }

            _heightInInches = value;
        }
    }

    public int WeightInPounds
    {
        get
        {
            return _weightInPounds;
        }

        private set
        {
            // if IsPositive is NOT true then ...
            if (!Utilities.IsPositive(value))
            {
                throw new ArgumentException("Weight must be positive.");
            }

            _weightInPounds = value;
        }
    }

    // coding this next one tonight but it will be discussed in more detail next class
    public DateOnly DateOfBirth
    {
        get
        {
            return _dateOfBirth;
        }

        private set
        {
            // can't be in the future, so we're going to pair it with a relational operator
            if (Utilities.IsInTheFuture(value))
            {
                throw new ArgumentException("Date of birth cannot be in the future.");
            }

            _dateOfBirth = value;
        }
    }

    // auto-implemented properties
        // this is allowed because we don't have to do any sort of validation since it can only be specified values from the enum
        // USE THIS FOR EXERCISE 1
    public Position Position { get; set; }

    public Shot Shot { get; set; }

    // constructors
        // you can always use the default constructor to instantiate an object by calling it the name of the class followed by empty parameters
        // greedy constructors - pass in parameters for all of the data fields or properties
        // object intializer - allows you to use the default constructor and only pass in specific parameters

    // default constructor:
    //    // if you don't specify a default constructor than the defaults for the data type are applied

    // commenting this out because it's just for example of how you could use a default constructor
    //public HockeyPlayer()
    //{
    //    // ensure that none of the non-nullable fields are null by assigning it a string.Empty value
    //    _firstName = string.Empty;
    //    _lastName = string.Empty;
    //    _birthPlace = string.Empty;
    //    _dateOfBirth = new DateOnly();
    //    _weightInPounds = 0;
    //    _heightInInches = 0;
    //    // this comes from our enum we created earlier
    //    Position = Position.Center;
    //    Shot = Shot.Left;
    //}

    // greedy constructor:
        // method overloading - same method with same name but changing the signature (adding parameters)
    public HockeyPlayer(string firstName, string lastName, string birthPlace, DateOnly dateOfBirth, int weightInPounds, int heightInInches, int jerseyNumber, Position position = Position.Center, Shot shot = Shot.Left)
        // ^^ the parameters that have values assigned to them are assigned those parameters if a value is not given to them in a new object instance
            // ex. HockeyPlayer player = new HockeyPlayer("jane", "doe", "edmonton", new DateOnly(), 1, 2); they would be assigned Position Center and Shot Left
    {
        // default parameters
        FirstName = firstName;
        LastName = lastName;
        BirthPlace = birthPlace;
        HeightInInches = heightInInches;
        WeightInPounds = weightInPounds;
        DateOfBirth = dateOfBirth;
        JerseyNumber = jerseyNumber;
        Shot = shot;
        Position = position;
    }

    public int JerseyNumber
    {
        get
        {
            return _jerseyNumber;
        }

        set
        {
            if (value < 1 || value > 98)
            {
                throw new ArgumentOutOfRangeException("Jersey Number should be between 1 and 98", new ArgumentException());
            }

            _jerseyNumber = value;
        }
    }

    public int Age => (DateOnly.FromDateTime(DateTime.Now).DayNumber - DateOfBirth.DayNumber) / 365;

    // Override ToString()
    // for example if you were to put Console.WriteLine(player1), this method would automatically output the object using the following template
    public override string ToString()
    {

        return $"{FirstName}, {LastName}";

    }
}

