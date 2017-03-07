using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Draci_doupe.Tridy
{
    public class InventoryDatabase
    {
        // SQLite connection
        public SQLiteAsyncConnection database;

        public InventoryDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Inventory>().Wait();
        }
        public Task<List<Inventory>> QueryDeleteAll()
        {
            return database.QueryAsync<Inventory>("DELETE FROM [Inventory]");
        }
        public Task<List<Inventory>> QueryGet()
        {
            return database.QueryAsync<Inventory>("SELECT * FROM [Inventory] ORDER BY ID DESC LIMIT 1;");
        }
        public Task<int> SaveItemAsync(Inventory item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
        public Task<List<Inventory>> GetItemsFromDatabase()
        {
            return database.QueryAsync<Inventory>("SELECT * FROM [Inventory] WHERE [Done] = 0");
        }
    }
}
