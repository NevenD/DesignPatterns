namespace Singleton
{

    // It's creation pattern
    // Singleton pattern is to ensure that class only has one instance, and to provide a global point of access to it

    /// <summary>
    /// Use cases: when there must be exactly one instance of a class
    /// must be accessible to clients from a well-known access point
    /// When the sole instance should be extensible by subclassing 
    /// and clients should be able to use an extended instance without modifying  their code
    /// 
    /// Pattern consequences: strict control over how and when clients access it
    /// Avoids polluting the namespace with global variables it's better then usage of global variables
    /// Multiple instances can be allowed without having to alter the client
    /// 
    /// Violetes the single responsibility principle - objects not control how they are created but how they managed their own lifecycle
    /// </summary>
    public class Logger
    {

        // Lazy<T> - 
        // it's readonly because it wont need to change during the singleton lifetime 
        // this is thread safe 
        private static readonly Lazy<Logger> _lazyLogger = new Lazy<Logger>(() => new Logger());
        //protected static Logger? _instance;

        public static Logger Instance
        {
            get
            {
                // Lazy instantiation, use it when needed 
                //if (_instance is null)
                //{
                //    _instance = new Logger();
                //}

                //return _instance;

                // the first time is constructed using the action we passed through when initializing the lazylogger
                // every time the same instance will be returned in the thread-safe manner
                //
                return _lazyLogger.Value;
            }
        }

        protected Logger() { }

        /// <summary>
        /// SingletonOperation
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            Console.WriteLine($"Message to log: ${message}");
        }
    }
}
