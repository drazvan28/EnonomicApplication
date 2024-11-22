using System;
using System.Collections.Generic;
using System.IO;

namespace EconomicEntity
{
    class Program
    {
        static List<MarketEntity> entities = new List<MarketEntity>();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                // Display menu
                Console.WriteLine("1. Add New Entity");
                Console.WriteLine("2. Display All Entities");
                Console.WriteLine("3. Save Entities to CSV");
                Console.WriteLine("4. Load Entities from CSV");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEntity();
                        break;
                    case "2":
                        DisplayEntities();
                        break;
                    case "3":
                        SaveEntitiesToCSV();
                        break;
                    case "4":
                        LoadEntitiesFromCSV();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void AddEntity()
        {
            Console.WriteLine("Select entity type:");
            Console.WriteLine("1. Consumer");
            Console.WriteLine("2. Market");
            string entityType = Console.ReadLine();

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Identifier: ");
            string identifier = Console.ReadLine();

            if (entityType == "1")
            {
                // Adding a Consumer
                Console.Write("Enter Age: ");
                int age;
                while (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
                {
                    Console.Write("Invalid age. Please enter a positive number: ");
                }

                Console.Write("Enter Location: ");
                string location = Console.ReadLine();
                
                entities.Add(new Consumer(name, identifier, age, location));
            }
            else if (entityType == "2")
            {
                // Adding a Market
                Console.Write("Enter Industry: ");
                string industry = Console.ReadLine();

                Console.Write("Enter Annual Revenue: ");
                double annualRevenue;
                while (!double.TryParse(Console.ReadLine(), out annualRevenue) || annualRevenue <= 0)
                {
                    Console.Write("Invalid revenue. Please enter a positive number: ");
                }

                entities.Add(new Market(name, identifier, industry, annualRevenue));
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid entity type.");
            }
        }

        static void DisplayEntities()
        {
            if (entities.Count == 0)
            {
                Console.WriteLine("No entities to display.");
                return;
            }

            foreach (var entity in entities)
            {
                Console.WriteLine(entity.GetEntityInfo());
            }
        }

        static void SaveEntitiesToCSV()
        {
            string filePath = "entities.csv";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Type,Name,Identifier,Industry,AnnualRevenue,Age,Location");

                    foreach (var entity in entities)
                    {
                        if (entity is Market market)
                        {
                            writer.WriteLine("Market," + market.Name + "," + market.Identifier + "," + market.Industry + "," + market.AnnualRevenue.ToString("F2") + ",,,");
                        }
                        else if (entity is Consumer consumer)
                        {
                            writer.WriteLine("Consumer," + consumer.Name + "," + consumer.Identifier + ",,,," + consumer.Age + "," + consumer.Location);
                        }
                    }
                }
                Console.WriteLine("Entities saved to CSV.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving to CSV: " + ex.Message);
            }
        }

        static void LoadEntitiesFromCSV()
        {
            string filePath = "entities.csv";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("CSV file not found.");
                return;
            }

            try
            {
                entities.Clear();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string header = reader.ReadLine(); // Skip the header line

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (values[0] == "Market")
                        {
                            string name = values[1];
                            string identifier = values[2];
                            string industry = values[3];
                            double annualRevenue = double.Parse(values[4]);
                            entities.Add(new Market(name, identifier, industry, annualRevenue));
                        }
                        else if (values[0] == "Consumer")
                        {
                            string name = values[1];
                            string identifier = values[2];
                            int age = int.Parse(values[6]);
                            string location = values[7];
                            entities.Add(new Consumer(name, identifier, age, location));
                        }
                    }
                }
                Console.WriteLine("Entities loaded from CSV.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading from CSV: " + ex.Message);
            }
        }
    }
}