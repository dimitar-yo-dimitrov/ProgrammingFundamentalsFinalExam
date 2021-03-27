using System;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Generate")
                {
                    break;
                }

                string[] tokens = line
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];

                if (command == "Contains")
                {
                    string substringText = tokens[1];

                    if (text.Contains(substringText))
                    {
                        Console.WriteLine($"{text} contains {substringText}");
                    }
                    else
                    {
                        Console.WriteLine($"Substring not found!");
                    }
                }

                else if (command == "Flip")
                {
                    string upperCase = tokens[1];
                    int startIndex = int.Parse(tokens[2]);
                    int endIndex = int.Parse(tokens[3]);
                    string substr = text.Substring(startIndex, endIndex - startIndex);
                    string replasment = substr.ToLower();

                    if (upperCase == "Upper")
                    {
                        replasment = substr.ToUpper();
                    }

                        text = text.Replace(substr, replasment);
                        Console.WriteLine(text);
                }

                else if (command == "Slice")
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);

                    text = text.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(text);
                }
            }

            Console.WriteLine($"Your activation key is: {text}");
        }
    }
}
