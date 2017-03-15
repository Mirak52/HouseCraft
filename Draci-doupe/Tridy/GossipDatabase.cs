using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Draci_doupe.Tridy
{
    public class GossipDatabase
    {
        // SQLite connection
        public SQLiteAsyncConnection database;

        public GossipDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Gossip>().Wait();
        }
        public Task<List<Gossip>> QueryDeleteAll()
        {
            return database.QueryAsync<Gossip>("DELETE FROM [Inventory]");
        }
        public Task<List<Gossip>> QueryGet()
        {
            return database.QueryAsync<Gossip>("SELECT * FROM [Inventory] ORDER BY ID DESC LIMIT 1;");
        }
        public Task<int> SaveItemAsync(Gossip item)
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
        public Task<List<Gossip>> GetItemsFromDatabase(int id)
        {
            return database.QueryAsync<Gossip>("SELECT * FROM [Gossip] WHERE [ID] = " + id);
        }

    }
}
