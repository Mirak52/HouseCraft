using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Draci_doupe.Tridy;
using SQLite;
namespace Draci_doupe.Třídy
{
    public class OsobyDatabase
    {
        // SQLite connection
        public SQLiteAsyncConnection database;

        public OsobyDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Osoby>().Wait();
        }
        public Task<List<Osoby>> QueryDeleteAll()
        {
            return database.QueryAsync<Osoby>("DELETE FROM [Osoby]");
        }
        public Task<List<Osoby>> QueryGet()
        {
            return database.QueryAsync<Osoby>("SELECT * FROM [Osoby] ORDER BY ID DESC LIMIT 1;");
        }
        public Task<int> SaveItemAsync(Osoby item)
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
        public Task<List<Osoby>> GetItemsFromDatabase()
        {
            return database.QueryAsync<Osoby>("SELECT * FROM [Osoby] WHERE [Done] = 0");
        }
    }
}
