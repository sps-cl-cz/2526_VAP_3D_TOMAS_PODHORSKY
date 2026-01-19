using Microsoft.Data.Sqlite;

namespace DatabaseApp;

class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Zadejte sve jmeno.");
            return;
        }
        Game game = new Game();
        int score = game.Play();
        string connectionString = "Data source=app.db";
        using SqliteConnection connection = new SqliteConnection(connectionString);
        connection.Open();
        SqliteCommand createTableCommand = connection.CreateCommand();
        createTableCommand.CommandText = @"
        CREATE TABLE IF NOT EXISTS players(
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                name TEXT NOT NULL,
                Score INTEGER NOT NULL
            );
        ";
        createTableCommand.ExecuteNonQuery();

        using SqliteCommand readCommand = connection.CreateCommand();
        readCommand.CommandText = "SELECT FROM Score Players WHERE Name = $name;";
        readCommand.Parameters.AddWithValue("$name", args[0]);
        object result = readCommand.ExecuteScalar();
        if (result == null)
        {
            using SqliteCommand insertCommand = connection.CreateCommand();
            insertCommand.CommandText = "INSERT INTO Players(Name, Score) VALUES($name, $score)";
            insertCommand.Parameters.AddWithValue("$name", args[0]);
            insertCommand.Parameters.AddWithValue("$score", score);
            insertCommand.ExecuteNonQuery();
        } else
        {
            long highScore = (long)result;
            if (highScore >= score)
            {
                Console.WriteLine($"Score: {score}");
                Console.WriteLine($"High Score: {highScore}");
            }
            else
            {
                //aktualizace nej skore
            }
        }
    }
}
