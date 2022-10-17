using System;
using System.Runtime.CompilerServices;

namespace ArdalisRating.Utils
{
    public static class Logger
    {
        public static void Log<ClassType>(string message, [CallerMemberName] string memberName = null) where ClassType : class
        {
            Console.WriteLine(value: $"{typeof(ClassType).Name}.{memberName}() - Message: {message}");
        }
    }
}