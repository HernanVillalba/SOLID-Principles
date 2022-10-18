using System.IO;
using System.Reflection.Metadata.Ecma335;

namespace ArdalisRating.Utils
{
    public static class FilePolicySource
    {
        public static string GetPolicyFromsource(string path) => File.ReadAllText(path);
    }
}