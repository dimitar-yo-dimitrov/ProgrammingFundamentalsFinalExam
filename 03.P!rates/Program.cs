using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03.P_rates
{
    class City
    {
        public string Name { get; set; }
        public long Population { get; set; }
        public long Gold { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> citys = ReadCity();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] tokens = line
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string cityName = tokens[1];
                
                City city = citys[cityName];
                
                if (command == "Plunder")
                {
                    int population = int.Parse(tokens[2]);
                    int gold = int.Parse(tokens[3]);

                    city.Population -= population;
                    city.Gold -= gold;
                    
                    Console.WriteLine($"{cityName} plundered! {gold} gold stolen, {population} citizens killed.");
                    

                        if (city.Population <= 0 || city.Gold <= 0)
                        {
                            citys.Remove(cityName);

                            Console.WriteLine($"{cityName} has been wiped off the map!");
                        }
                }

                else if (command == "Prosper")
                {
                    int gold = int.Parse(tokens[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        continue;
                    }

                    city.Gold += gold;

                    Console.WriteLine($"{gold} gold added to the city treasury. {cityName} now has {city.Gold} gold.");
                }
            }

            Dictionary<string, City> sorted = citys
                .OrderByDescending(c => c.Value.Gold)
                .ThenBy(c => c.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            if (sorted.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }

            else
            {
                Console.WriteLine($"Ahoy, Captain! There are {citys.Count} wealthy settlements to go to:");

                foreach (City city in sorted.Values)
                {
                    Console.WriteLine($" {city.Name} -> Population: {city.Population} citizens, Gold: {city.Gold} kg");
                }
            }
        }
        
        private static Dictionary<string, City> ReadCity()
        {
           
         Dictionary<string, City> citys = new Dictionary<string, City>();
            
         while (true)
            {
                string line = Console.ReadLine();

                if (line == "Sail")
                {
                    break;
                }

                string[] parts = line
                    .Split("||", StringSplitOptions.RemoveEmptyEntries);

                string cityName = parts[0];
                long population = long.Parse(parts[1]);
                long gold = long.Parse(parts[2]);

                if (citys.ContainsKey(cityName))
                {
                    City city = citys[cityName];
                    city.Population += population;
                    city.Gold += gold;
                }

                else
                {
                    City city = new City
                    {
                        Name = cityName,
                        Population = population,
                        Gold = gold
                    };

                    citys.Add(cityName, city);
                }
            }
            
            return citys;
        }
    }
}
