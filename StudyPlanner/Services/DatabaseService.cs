

using SQLite;
using StudyPlanner.Models;

namespace StudyPlanner.Services;

public class DatabaseService
{
    private const string DBName = "StudyPlanner_db.db3";

    private readonly SQLiteAsyncConnection _connection;

    public DatabaseService() 
    {
        _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DBName));

        _connection.CreateTableAsync<Key>();
    }

    public async Task<int> InsertKey(Key item)
    {
        return await _connection.InsertAsync(item);
    }

    public async Task<List<Key>> GetKey()
    {
        return await _connection.Table<Key>().ToListAsync();
    }
}