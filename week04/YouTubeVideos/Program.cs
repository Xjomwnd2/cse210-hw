using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static string filePath = "youtube_links.txt";

    static void Main()
    {
        List<string> videoLinks = new List<string>();

        if (File.Exists(filePath))
        {
            videoLinks.AddRange(File.ReadAllLines(filePath));
        }

        string choice;
        do
        {
            Console.WriteLine("\nYouTube Video Manager");
            Console.WriteLine("1. Add a YouTube video link");
            Console.WriteLine("2. List all saved video links");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddVideoLink(videoLinks);
                    break;
                case "2":
                    ListVideoLinks(videoLinks);
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        } while (choice != "3");
    }

    static void AddVideoLink(List<string> videoLinks)
    {
        Console.Write("Enter YouTube video link: ");
        string link = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(link) && link.StartsWith("https://www.youtube.com"))
        {
            videoLinks.Add(link);
            File.AppendAllLines(filePath, new[] { link });
            Console.WriteLine("Video link saved successfully!");
        }
        else
        {
            Console.WriteLine("Invalid YouTube link. Please enter a valid URL.");
        }
    }

    static void ListVideoLinks(List<string> videoLinks)
    {
        if (videoLinks.Count == 0)
        {
            Console.WriteLine("No YouTube videos saved yet.");
        }
        else
        {
            Console.WriteLine("\nSaved YouTube Video Links:");
            foreach (var link in videoLinks)
            {
                Console.WriteLine(link);
            }
        }
    }
}
