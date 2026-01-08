namespace Tridy;
class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2){
            Console.WriteLine("Nedostatecny pocet arg");
            return;
        }
        string title = args[0];
        bool completed = args[1].ToLower().Trim() == "splneno";
        MyTask task = new MyTask(title, completed);
        System.IO.File.WriteAllText("tasks.txt", task.ToString());
    }
}