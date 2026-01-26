using DatabaseAppEf;

namespace ConsoleGame
{
    public static void Main(string[] args)
    {
        string name;
        if (args.Length == 0)
        {
            Console.WriteLine("zadejte sve jemeno.");
            name = Console.ReadLine();
        }
        else
            name = args[0];

        int score = new Game().Play();
        using SQLiteDbContext context = new SQLiteDbContext();
        context.Database.EnsureCreated();
        Player player = context.Players.FirstOrDefault(p => p.Name == name);
        if (player == null)
        {
            player = new Player()
            {
                Name = name,
                HighScore = score,
            };
            context.Players.Add(player);
        } else
        {
            player.HighScore = Math.Max(score, player.HighScore)
        }
        context.SaveChanges();
    }
}