using System;
using System.IO;

namespace IMusic.Env
{
    public class DotEnv
    {
        public static void Load(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                // Split only at the first '='
                var indexOfEqualSign = line.IndexOf('=');
                if (indexOfEqualSign > 0)
                {
                    var key = line.Substring(0, indexOfEqualSign).Trim(); // Get key
                    var value = line.Substring(indexOfEqualSign + 1).Trim(); // Get value

                    // Check if the value is enclosed in quotes
                    if (value.StartsWith("\"") && value.EndsWith("\""))
                    {
                        value = value[1..^1]; // Remove surrounding quotes
                    }

                    // Set the environment variable
                    Environment.SetEnvironmentVariable(key, value);
                }
            }
        }
    }

}
