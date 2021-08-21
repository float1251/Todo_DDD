using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using TodoApp.Domain.Todo;

namespace TodoApp.Infrastructure.Todo
{
    public class TodoRepository : ITodoRepository, IDisposable
    {
        private readonly LiteDatabase db;

        public TodoRepository(string path)
        {
            this.db = new LiteDatabase(path);
        }

        public async Task<IEnumerable<Domain.Todo.Todo>> FindAll()
        {
            var col = this.db.GetCollection<TodoModel>();
            var res = col.FindAll()
                .Select(v => new TodoApp.Domain.Todo.Todo(new TodoId(v.id), v.name, v.IsDone()));
            await Task.CompletedTask;
            return res;
        }

        public async Task<Domain.Todo.Todo> CreateTask(string name)
        {
            var col = this.db.GetCollection<TodoModel>();
            var todo = new TodoApp.Domain.Todo.Todo(name);
            col.Insert(new TodoModel(todo));
            await Task.CompletedTask;
            return todo;
        }

        public async Task<Domain.Todo.Todo> UpdateTask(Domain.Todo.Todo todo)
        {
            var col = db.GetCollection<TodoModel>();
            col.Update(new TodoModel(todo));
            await Task.CompletedTask;
            return todo;
        }

        public Domain.Todo.Todo DeleteTask(TodoId todoId)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            this.db?.Dispose();
        }
    }
}