using System;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex digit = new Regex(@"\d");
            Regex emojiRegex = new Regex(@"(::|\*\*)([A-Z][a-z]{2,})\1");

            string text = Console.ReadLine();

            MatchCollection allDidits = digit.Matches(text);
            long threshold = GetSumOfThreshold(allDidits);
            Console.WriteLine($"Cool threshold: {threshold}");

            MatchCollection emojiMatches = emojiRegex.Matches(text);
            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");

            foreach (Match emojiMatch in emojiMatches)
            {
                string emojiText = emojiMatch.Groups[2].Value;
                long coolness = GetAsciSum(emojiText);

                if (coolness > threshold)
                {
                    Console.WriteLine(emojiMatch);
                }
            }

        }

        private static long GetAsciSum(string text)
        {
            long sum = 0;

            foreach (char letter in text)
            {
                sum += letter;
            }

            return sum;
        }

        private static long GetSumOfThreshold(MatchCollection allDidits)
        {
            int sum = 1;

            foreach (Match digit in allDidits)
            {
                sum *= int.Parse(digit.Value);
            }

            return sum;
        }
    }
}
