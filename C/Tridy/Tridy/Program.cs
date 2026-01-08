namespace Tridy;
class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 3){
            Console.WriteLine("Nedostatecny pocet arg");
            return;
        }
        string operation = args[0].ToLower().Trim();
        string title = args[1];
        bool completed = args[2].ToLower().Trim() == "splneno";
        if (operation == "pridat")
        {
            string[] lines = File.ReadAllLines("tasks.txt");
            Dictionary<int, MyTask> tasks = ParseFile(lines);
            MyTask task = new MyTask(title, completed);
            tasks.Add(task.Id, task);
            File.WriteAllLines("tasks.txt", TasksToString(tasks));
        }

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
        Dictionary<int, MyTask> dicitonary = new Dictionary<int, MyTask>();

        foreach (string line in lines)
        {
            try
            { string[] parts = line.Split(",");
            string title = parts[0].Split(":")[1].Trim();
            string completed = parts[1].Split(":")[1].Trim();
            string id = parts[2].Split(":")[1].Trim();
            MyTask task = new MyTask(title, bool.Parse(completed), int.Parse(id));
                dicitonary.Add(task.Id, task);
            } catch { }
        }
        return dicitonary;
    } 
}