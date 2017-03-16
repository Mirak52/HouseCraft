using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Draci_doupe.Tridy;
using SQLite;
namespace Draci_doupe.Třídy
{
    public class RequirementDatabase
    {
        // SQLite connection
        public SQLiteAsyncConnection database;

        public RequirementDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Requirement>().Wait();
        }
        public Task<List<Requirement>> QueryDeleteAll()
        {
            return database.QueryAsync<Requirement>("DELETE FROM [Requirement]");
        }
        public Task<List<Requirement>> QueryGet()
        {
            return database.QueryAsync<Requirement>("SELECT * FROM [Requirement] ORDER BY ID DESC LIMIT 1;");
        }
        public Task<int> SaveItemAsync(Requirement item)
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
        public Task<List<Requirement>> GetItemsFromDatabase(int id)
        {
            return database.QueryAsync<Requirement>("SELECT * FROM [Requirement] WHERE [ID] = " + id);
        }
    }
}
