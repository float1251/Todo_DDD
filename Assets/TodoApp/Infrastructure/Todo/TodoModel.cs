using Codice.Client.BaseCommands;
using TodoApp.Domain.Todo;

namespace TodoApp.Infrastructure.Todo
{
    public class TodoModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public TodoStatus done { get; set; }

        public TodoModel()
        {
        }

        public TodoModel(TodoApp.Domain.Todo.Todo todo)
        {
            this.id = todo.id.id;
            this.name = todo.name;
            this.done = todo.status;
        }

        public bool IsDone()
        {
            return done == TodoStatus.Done;
        }
    }
}