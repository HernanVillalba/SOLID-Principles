using System;
using System.IO;

namespace ArdalisRating.Utils
{
    public interface IFilePolicySource
    {
        string GetPolicyFromsource(string path);

        void WriteInfile(string path, string text);
    }

    public class FilePolicySource : IFilePolicySource
    {
        public string GetPolicyFromsource(string path) => File.ReadAllText(path);

        public void WriteInfile(string path, string text) => File.WriteAllText(path, text);
    }
}