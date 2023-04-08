using Singleton;

Console.Title = "Singleton pattern";

//var test = new Logger(); // this is not possible due to protection level

var instance1 = Logger.Instance;
var instance2 = Logger.Instance;

if (instance1 == instance2 && instance2 == Logger.Instance)
{
    Console.WriteLine("Instances are the same.");
}

instance1.Log($"message from {nameof(instance1)}");
instance2.Log($"message from {nameof(instance2)}");

Logger.Instance.Log($"Message from {nameof(Logger.Instance)}");

Console.ReadLine();