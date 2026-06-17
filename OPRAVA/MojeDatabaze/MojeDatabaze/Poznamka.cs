using SQLite;

namespace MojeDatabaze;

public class Poznamka
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Text { get; set; }
}