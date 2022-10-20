using System;
using System.Runtime.CompilerServices;

namespace ArdalisRating.Utils
{
    public interface ILogger
    {
        void Log<ClassType>(string message, [CallerMemberName] string memberName = null) where ClassType : class;
    }

    public class Logger : ILogger
    {
        public void Log<ClassType>(string message, [CallerMemberName] string memberName = null) where ClassType : class
        {
            Console.WriteLine(value: $"{typeof(ClassType).Name}.{memberName}() - Message: {message}");
        }
    }
}