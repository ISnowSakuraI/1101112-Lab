using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Lab5.Models;

namespace Lab5.Services
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait(); // สร้างตาราง User หากยังไม่มี
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(int id)
        {
            return _database.Table<User>().Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public Task<User> GetLatestUserAsync()
        {
            return _database.Table<User>().OrderByDescending(u => u.Id).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.Id != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
    }
}