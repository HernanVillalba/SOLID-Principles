using System.IO;

namespace ArdalisRating.Utils
{
    public static class FilePolicySource
    {
        public static string GetPolicyFromsource(string path) => File.ReadAllText(path);

        public static void WriteInfile(string path, string text) => File.WriteAllText(path, text);
    }
}