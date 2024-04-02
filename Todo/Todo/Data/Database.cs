using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Todo.Models;

namespace XFSQLiteSample
{
    internal class Database
    {
        private readonly SQLiteAsyncConnection _database;
        public Database(String dbpath)
        {
            _database = new SQLiteAsyncConnection(dbpath);
            _database.CreateTableAsync<TodoItem>();
        }
        public Task<List<TodoItem>> GetStudentAsync()
        {
            return _database.Table<TodoItem>().ToListAsync();
        }
        public Task<int> SaveStudentAsync(TodoItem student)
        {
            return _database.InsertAsync(student);
        }
    }
}
