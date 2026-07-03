using SQLite;

namespace BlazingHybridClient.Data;

public class DatabaseContext: IAsyncDisposable
{
    private const string DbFileName = "BlazingHybridClient.db3";
    private static string DbPath => Path.Combine(FileSystem.AppDataDirectory, DbFileName);
    private readonly SQLiteAsyncConnection _connection;

    public DatabaseContext()
    {
        _connection = new SQLiteAsyncConnection(DbPath, 
            SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);
    }

    private async Task CreateTableIfNotExists() =>
        _connection.CreateTableAsync<RequestHistory>().GetAwaiter().GetResult();

    public async Task<List<RequestHistory>> GetRequestHistoriesAsync()
    {
        await CreateTableIfNotExists();
        return await _connection.Table<RequestHistory>().ToListAsync();
    }

    public async Task AddRequestHistoryAsync(RequestHistory requestHistory)
    {
        await CreateTableIfNotExists();
        await _connection.InsertAsync(requestHistory);
    }

    public async Task DeleteAllRequestHistoriesAsync()
    {
        await CreateTableIfNotExists();
        await _connection.DeleteAllAsync<RequestHistory>();
    }

    public async Task DeleteRequestHistoryByIdAsync(int id)
    {
        await CreateTableIfNotExists();
        await _connection.DeleteAsync<RequestHistory>(id);
    }

    public async ValueTask DisposeAsync() => await _connection.CloseAsync();
}