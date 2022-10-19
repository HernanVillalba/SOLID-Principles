using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace ArdalisRating.Appplication.Services.Local
{
    public interface ILoggerService
    {
        void Log<ClassType>(string message, [CallerMemberName] string memberName = null) where ClassType : class;
    }

    public class ConsoleLoggerService : ILoggerService
    {
        public void Log<ClassType>(string message, [CallerMemberName] string memberName = null) where ClassType : class
        {
            Console.WriteLine(value: $"{typeof(ClassType).Name}.{memberName}() - Message: {message}");
        }
    }

    public class FileLoggerService : ILoggerService
    {
        public void Log<ClassType>(string message, [CallerMemberName] string memberName = null) where ClassType : class
        {
            using StreamWriter stream = File.AppendText("logs.txt");

            stream.WriteLine($"{typeof(ClassType).Name}.{memberName}() - Message: {message}");

            stream.Flush();
        }
    }
}