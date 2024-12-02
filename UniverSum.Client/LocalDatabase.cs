using SQLite;
using UniverSum.Client.Models;

namespace UniverSum.Client
{
    public class LocalDatabase
    {
        SQLiteAsyncConnection Database;
        public LocalDatabase()
        {
        }
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<Setting>();
        }

        public async Task<List<Setting>> GetSettingsAsync()
        {
            await Init();
            return await Database.Table<Setting>().ToListAsync();
        }

        public async Task<Setting> GetSettingAsync(int id)
        {
            await Init();
            return await Database.Table<Setting>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveSettingAsync(Setting item)
        {
            await Init();
            if (item.Id != 0)
            {
                return await Database.UpdateAsync(item);
            }
            else
            {
                return await Database.InsertAsync(item);
            }
        }
    }
}
