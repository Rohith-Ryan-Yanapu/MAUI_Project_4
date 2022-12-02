using SQLite;
using Calculator.Models;
namespace Calculator.Data;

public class HistoryDatabase
{
    SQLiteAsyncConnection Database;
    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<HistoryItem>();
    }

    public async Task<int> SaveItemAsync(String exp)
    {
        await Init();
        return await Database.InsertAsync(new HistoryItem { Expression = exp });
    }
    
}