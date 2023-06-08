using System.Text;

namespace BuilderPattern
{

    // The intent of pattern is to separate the construction of a complex object
    // from its representation.
    // The same construction process can create different representations

    // It is a common patter from the gang of four
    // Define the abstract class or a interface
    // USE cases
    // make the algorithm for creating a complex object independent of the parts that make up the object
    // and how they are assembled

    // It isoletes code for construction and representation (it is single responsibility principle)
    // it gives us finer control over the construction process

    // Complexity of code base increases

    // Builder patter is related to the abstract factory and singleton

    // inte

    ///<summary>
    /// Product
    /// </summary>
    public class Car
    {
        private readonly List<string> _parts = new();
        private readonly string _carType;

        public Car(string carType)
        {
            _carType = carType;
        }

        public void AddPart(string part)
        {
            _parts.Add(part);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var part in _parts)
            {
                sb.Append($"Car of type {_carType} has part {part}. ");
            }

            return sb.ToString();
        }
    }

    ///<summary>
    /// Builder
    /// Abstract base class for concrete builders
    /// </summary>
    public abstract class CarBuilder
    {
        public Car Car { get; private set; }

        public CarBuilder(string carType)
        {
            Car = new Car(carType);
        }

        public abstract void BuildEngine();
        public abstract void BuildFrame();
    }

    ///<summary>
    /// Concrete Builder class 1
    /// </summary>
    /// 
    public class MiniBuilder : CarBuilder
    {
        public MiniBuilder()
            // passing car type to the base constructor
            : base("Mini")
        {

        }

        public override void BuildEngine()
        {
            Car.AddPart("'not a V8'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'3-door with stripes'");

        }
    }

    ///<summary>
    /// Concrete Builder class 2
    /// </summary>
    /// 
    public class BMWBuilder : CarBuilder
    {
        public BMWBuilder()
            : base("BMW")
        {
        }

        public override void BuildEngine()
        {
            Car.AddPart("'a fancy V8 engine'");
        }

        public override void BuildFrame()
        {
            Car.AddPart("'5-door with metallic finish'");
        }
    }

    ///<summary>
    /// Director- needs builder to effectively construct something
    /// </summary>
    /// 
    public class Garage
    {
        public CarBuilder? _builder;

        public Garage()
        {

        }

        public void Construct(CarBuilder builder)
        {
            _builder = builder;
            _builder.BuildEngine();
            _builder.BuildFrame();
        }

        public void Show()
        {
            Console.WriteLine(_builder?.Car.ToString());
        }

    }
}
