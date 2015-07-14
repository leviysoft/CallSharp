using System;

namespace CallSharp
{
    /// <summary>
    /// Generic extension methods for monadic exception handling
    /// </summary>
    public static class CallSharpExtensionMethods
    {
        /// <summary>
        /// Wraps a function call in Func&lt;&gt;
        /// </summary>
        /// <param name="instance">Object, which method must be called</param>
        /// <param name="call">Method call function</param>
        /// <typeparam name="T">Type of the object</typeparam>
        /// <typeparam name="TRes">Result type</typeparam>
        /// <returns>Function that calls the method of the object and returns the result</returns>
        public static Func<TRes> Call<T, TRes>(this T instance, Func<T, TRes> call)
        {
            return () => call(instance);
        }

        /// <summary>
        /// Wraps a function call in a try/catch block
        /// </summary>
        /// <param name="func">A function to call</param>
        /// <param name="convertor">A function that computes some value based on exception instance</param>
        /// <typeparam name="TRes">Type of the result</typeparam>
        /// <typeparam name="TException">Type of the exception</typeparam>
        /// <returns>Some value</returns>
        public static Func<TRes> Catch<TRes, TException>(this Func<TRes> func, Func<TException, TRes> convertor)
            where TException : Exception
        {
            return () =>
            {
                try
                {
                    return func();
                }
                catch (TException ex)
                {
                    return convertor(ex);
                }
            };
        }
    }
}
