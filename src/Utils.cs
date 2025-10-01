using System;

namespace jumpstart
{
    public static class Utils
    {
        /// <summary>
        /// Converts a string from snake_case to PascalCase
        /// </summary>
        /// <param name="input">The input string in snake_case format</param>
        /// <returns>The converted string in PascalCase format</returns>
        public static string ConvertToPascalCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string[] parts = input.Split('_');
            return string.Concat(Array.ConvertAll(parts, part => char.ToUpper(part[0]) + part.Substring(1).ToLower()));
        }
    }
}
