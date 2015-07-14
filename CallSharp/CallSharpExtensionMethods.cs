using System;

namespace CallSharp
{
    public static class CallSharpExtensionMethods
    {
        public static Func<TRes> Call<T, TRes>(this T instance, Func<T, TRes> call)
        {
            return () => call(instance);
        }

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
