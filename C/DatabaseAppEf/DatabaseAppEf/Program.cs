using System;
using System.Linq;
using DatabaseAppEf;

namespace ConsoleGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Zadej své jméno:");
            string name = args.Length > 0 ? args[0] : Console.ReadLine();

            int score = new Game().Play();

            using SQLiteDbContext context = new SQLiteDbContext();
            context.Database.EnsureCreated();

            Player player = context.Players.FirstOrDefault(p => p.Name == name);

            if (player == null)
            {
                player = new Player
                {
                    Name = name,
                    HighScore = score
                };
                context.Players.Add(player);
            }
            else
            {
                player.HighScore = Math.Max(player.HighScore, score);
            }

            context.SaveChanges();
        }
    }
}
