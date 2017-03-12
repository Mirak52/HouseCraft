using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Draci_doupe.Tridy
{
    public class EnemiesDatabase
    {
        // SQLite connection
        public SQLiteAsyncConnection database;

        public EnemiesDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Enemies>().Wait();
        }
        public Task<List<Enemies>> QueryDeleteAll()
        {
            return database.QueryAsync<Enemies>("DELETE FROM [Enemies]");
        }
        public Task<List<Enemies>> QueryGet()
        {
            return database.QueryAsync<Enemies>("SELECT * FROM [Enemies] ORDER BY ID DESC LIMIT 1;");
        }
        public Task<int> SaveItemAsync(Enemies item)
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
        public Task<List<Enemies>> GetItemsFromDatabase(int id)
        {
            return database.QueryAsync<Enemies>("SELECT * FROM [Enemies] WHERE [ID] = " + id );
        }
    }
}
