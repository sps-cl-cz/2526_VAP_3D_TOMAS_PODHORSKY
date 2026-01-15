using System;
using System.Collections.Generic;
using System.IO;

namespace Tridy
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Nedostatecny pocet argumentu");
                return;
            }

            string operation = args[0].ToLower().Trim();
            string[] lines = File.Exists("tasks.txt") ? File.ReadAllLines("tasks.txt") : Array.Empty<string>();
            Dictionary<int, MyTask> tasks = ParseFile(lines);

            switch (operation)
            {
                case "pridat":
                    if (args.Length < 3)
                    {
                        Console.WriteLine("Nedostatecny pocet argumentu");
                        return;
                    }

                    string title = args[1];
                    bool completed = args[2].ToLower().Trim() == "splneno";
                    MyTask task = new MyTask(title, completed);
                    tasks.Add(task.Id, task);
                    break;

                case "zobrazit":
                    foreach (MyTask myTask in tasks.Values)
                    {
                        Console.WriteLine(myTask);
                    }
                    break;

                case "smazat":
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Nedostatecny pocet argumentu");
                        return;
                    }

                    if (int.TryParse(args[1], out int removeId))
                    {
                        Console.WriteLine(tasks.Remove(removeId) ? "smazano" : "neni");
                    }
                    else
                    {
                        Console.WriteLine("chyba");
                    }
                    break;

                case "aktualizovat":
                    if (args.Length < 3)
                    {
                        Console.WriteLine("Nedostatecny pocet argumentu");
                        return;
                    }

                    try
                    {
                        int id = int.Parse(args[1]);
                        bool isCompleted = args[2].Trim().ToLower() == "splneno";

                        if (tasks.ContainsKey(id))
                        {
                            tasks[id].Completed = isCompleted;
                        }
                        else
                        {
                            Console.WriteLine("Uloha nenalezena");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("chyba");
                    }
                    break;
            }

            File.WriteAllLines("tasks.txt", TasksToString(tasks));
        }

        // metoda pro prevod slovniku s ulohami na txt retezec
        static List<string> TasksToString(Dictionary<int, MyTask> tasks)
        {
            List<string> result = new List<string>();
            foreach (MyTask value in tasks.Values)
            {
                result.Add(value.ToString());
            }
            return result;
        }

        static Dictionary<int, MyTask> ParseFile(string[] lines)
        {
            Dictionary<int, MyTask> dictionary = new Dictionary<int, MyTask>();

            foreach (string line in lines)
            {
                try
                {
                    string[] parts = line.Split(",");
                    string title = parts[0].Split(":")[1].Trim();
                    string completed = parts[1].Split(":")[1].Trim();
                    string id = parts[2].Split(":")[1].Trim();

                    MyTask task = new MyTask(title, bool.Parse(completed), int.Parse(id));
                    dictionary.Add(task.Id, task);
                }
                catch
                {
                }
            }

            return dictionary;
        }
    }
}
