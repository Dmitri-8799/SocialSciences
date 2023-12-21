using SQLite;
using System.Collections;

namespace SocialSciencesDecember2023.RadioButtons3;

public partial class Logic_TableRB3 : ContentPage
{
    //БУДЕТ ЛИ ЭТА БД ОБНОВЛЯТЬСЯ АВТОМАТИЧЕСКИ

    SQLiteAsyncConnection dbRB3;

    public Logic_TableRB3(string databasePath)
    {

        dbRB3 = new SQLiteAsyncConnection(databasePath);
    }

    //сделал методы подключения таблицы

    public async Task CreateTable()
    {
        await dbRB3.CreateTableAsync<TableRB3>();
    }

    public async Task<List<TableRB3>> GetItemsAsync()
    {
        return await dbRB3.Table<TableRB3>().ToListAsync();
    }

    public async Task<TableRB3> GetItemsAsync(int id)
    {
        return await dbRB3.GetAsync<TableRB3>(id);

    }

    public async Task<int> SaveItemAsync(TableRB3 item)
    {
        if (item.Id != 0)
        {
            await dbRB3.UpdateAllAsync((IEnumerable)item);
            return (item.Id);
        }

        else
        {
            return await dbRB3.InsertAllAsync((IEnumerable)item);
        }

    }
}


