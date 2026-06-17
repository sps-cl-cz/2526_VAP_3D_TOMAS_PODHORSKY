using SQLite;

namespace MojeDatabaze;

public class Databaze
{
    private SQLiteAsyncConnection _db;

    public Databaze()
    {
        string cesta = Path.Combine(FileSystem.AppDataDirectory, "mojedatabaze.db3");
        _db = new SQLiteAsyncConnection(cesta);

        _db.CreateTableAsync<Poznamka>().Wait();
    }

    public Task<List<Poznamka>> ZiskejPoznamkyAsync()
    {
        return _db.Table<Poznamka>().ToListAsync();
    }

    public Task<int> UlozPoznamkuAsync(Poznamka poznamka)
    {
        return _db.InsertAsync(poznamka);
    }
}