namespace KonzolovaApp
{
    class NameTask
    {
        public string Name { get; set; }
        public int[] Grades { get; set; }

        public NameTask(string name, int[] grades)
        {
            Name = name;
            Grades = grades;
        }

        public double GetAverage()
        {
            int sum = 0;
            for (int i = 0; i < Grades.Length; i++)
            {
                sum += Grades[i];
            }
            return (double)sum / Grades.Length;
        }

        public override string ToString()
        {
            return Name + " " + GetAverage().ToString("0.00");
        }

        public static NameTask Parse(string line)
        {
            string[] parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = parts[0];
            int[] grades = new int[parts.Length - 1];

            for (int i = 1; i < parts.Length; i++)
            {
                grades[i - 1] = int.Parse(parts[i]);
            }

            return new NameTask(name, grades);
        }
    }
}
