using SQLite;
using Calculator.Models;
namespace Calculator.Data;

public class HistoryDatabase
{
    SQLiteAsyncConnection Database;
    public HistoryDatabase()
    {
    }
    async Task Init()
    {
        if (Database is not null)
            return;

        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        var result = await Database.CreateTableAsync<HistoryItem>();
    }

    public async Task<List<HistoryItem>> GetItemsAsync()
    {
        await Init();
        return await Database.Table<HistoryItem>().ToListAsync();
    }

    //public async Task<List<HistoryItem>> GetItemsNotDoneAsync()
    //{
    //   await Init();
    //    return await Database.Table<HistoryItem>().Where(t => t.Done).ToListAsync();
        
        // SQL queries are also possible
        //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
    //}

    //public async Task<HistoryItem> GetItemAsync(int id)
    //{
    //    await Init();
    //    return await Database.Table<HistoryItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
    //}

    public async Task<int> SaveItemAsync(String exp)
    {
        await Init();
        return await Database.InsertAsync(new HistoryItem { Expression = exp });
    }
    public async Task<int> DeleteItemAsync(HistoryItem item)
    {
        await Init();
        return await Database.DeleteAsync(item);
    }
    public async Task<int> DeleteAllItems()
    {
        await Init();
        return await Database.DeleteAllAsync<HistoryItem>();
    }
}