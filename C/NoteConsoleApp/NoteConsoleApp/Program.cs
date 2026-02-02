using System;
using System.Linq;

namespace DatabaseAppEf
{
    class Program
    {
        static void Main()
        {
            using var db = new SQLiteDbContext();
            db.Database.EnsureCreated();

            while (true)
            {
                Console.WriteLine("\n1 - Přidat poznámku");
                Console.WriteLine("2 - Vypsat poznámky");
                Console.WriteLine("3 - Smazat poznámku");
                Console.WriteLine("0 - Konec");

                var volba = Console.ReadLine();

                if (volba == "0") break;

                if (volba == "1")
                {
                    Console.Write("Název: ");
                    var title = Console.ReadLine();

                    Console.Write("Popis: ");
                    var desc = Console.ReadLine();

                    db.Notes.Add(new Note
                    {
                        Title = title,
                        Description = desc
                    });
                    db.SaveChanges();
                }

                if (volba == "2")
                {
                    foreach (var note in db.Notes)
                    {
                        Console.WriteLine($"{note.Id}: {note.Title} – {note.Description}");
                    }
                }

                if (volba == "3")
                {
                    Console.Write("Zadej ID: ");
                    int id = int.Parse(Console.ReadLine());

                    var note = db.Notes.FirstOrDefault(n => n.Id == id);
                    if (note != null)
                    {
                        db.Notes.Remove(note);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
