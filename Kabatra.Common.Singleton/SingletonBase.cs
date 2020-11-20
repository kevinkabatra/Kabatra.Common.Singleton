namespace Kabatra.Common.Singleton
{
    /// <summary>
    ///     A base class for Singletons.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>
    ///     While this is a rather simple implementation, I am rather tire of having to repeat it.
    /// </remarks>
    public abstract class SingletonBase<T> where T : SingletonBase<T>, new()
    {
        private static T _singletonInstance;
        private static readonly object ThreadSafeLock = new object();
        
        /// <summary>
        ///     Gets or creates an instance of the singleton.
        /// </summary>
        /// <returns></returns>
        public static T GetOrCreateInstance()
        {
            if(_singletonInstance == null)
            {
                // lock will prevent multiple threads from attempting to create the singleton.
                lock (ThreadSafeLock)
                {
                    // should check conditional again, after lock is released the singleton would have been creates=d during a previous thread.
                    if (_singletonInstance == null)
                    {
                        _singletonInstance = new T();
                    }
                }
            }

            return _singletonInstance;
        }

        /// <summary>
        ///     Resets the singleton, this is required for unit testing.
        /// </summary>
        public static void Reset()
        {
            lock (ThreadSafeLock)
            {
                _singletonInstance = null;
            }
        }
    }
}
