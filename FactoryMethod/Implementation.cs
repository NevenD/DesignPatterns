namespace FactoryMethod
{

    // It's creation pattern
    // Factory method the intent of the factory method pattern is to define an interface
    // for creating an object, but to let subclasses decide which class to instantiate.
    // Factory method lets a class defer instantiation to subclasses
    // When a class can't anticipate the class of objects it must create
    // When a class wants its subclasses to specify the objects it creates
    // When classes delegate the responsibility to one of several helper subclasses

    // Pattern consequences eliminate the need to bind application-specific classes to your code
    // New types of products can be added without breaking client code

    // ITENT OF FACTORY METHOD
    // -define an interface for creating an object but to let subclasses decide which class
    // to instatiate

    public abstract class DiscountService
    {
        public abstract int DiscountPercentage { get; }
        public override string ToString() => GetType().Name;
    }

    /// <summary>
    /// Concrete product
    /// </summary>
    public class CountryDiscountService : DiscountService
    {
        private readonly string _countryIdentifier;

        public CountryDiscountService(string countryIdentifier)
        {
            _countryIdentifier = countryIdentifier;
        }

        public override int DiscountPercentage
        {
            get
            {
                switch (_countryIdentifier)
                {
                    case "BE":
                        return 20;
                    default:
                        return 10;
                }
            }
        }
    }


    public class CodeDiscountService : DiscountService
    {
        private readonly Guid _guid;

        public CodeDiscountService(Guid code)
        {
            _guid = code;
        }

        public override int DiscountPercentage
        {
            // each code returns the same fixed percentage, but a code is only 
            // valid once - include a check to so whether the code's been used before
            // ...
            get => 15;
        }
    }


    public abstract class DiscountFactory
    {
        public abstract DiscountService CreateDiscountService();
    }

    public class CountryDiscountFactory : DiscountFactory
    {
        private readonly string _countryIdentifier;

        public CountryDiscountFactory(string countryIdentifier)
        {
            _countryIdentifier = countryIdentifier;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CountryDiscountService(_countryIdentifier);
        }
    }

    public class CodeDiscountFactory : DiscountFactory
    {
        private readonly Guid _code;

        public CodeDiscountFactory(Guid code)
        {
            _code = code;
        }

        public override DiscountService CreateDiscountService()
        {
            return new CodeDiscountService(_code);
        }
    }

}



