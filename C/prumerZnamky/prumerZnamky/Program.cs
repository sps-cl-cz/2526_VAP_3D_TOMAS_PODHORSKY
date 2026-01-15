namespace KonzolovaApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("nedostatecny pocet argumentu");
                return;
            }

            string inputFile = args[0];
            string outputFile = args[1];

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("vstupni soubor neexistuje");
                return;
            }

            string[] lines = File.ReadAllLines(inputFile);
            List<NameTask> subjects = new List<NameTask>();

            foreach (string line in lines)
            {
                try
                {
                    NameTask task = NameTask.Parse(line);
                    subjects.Add(task);
                }
                catch
                {
                }
            }

            List<string> output = new List<string>();
            foreach (NameTask subject in subjects)
            {
                output.Add(subject.ToString());
            }

            File.WriteAllLines(outputFile, output);
            Console.WriteLine("vypocet dokoncen");
        }
    }
}
