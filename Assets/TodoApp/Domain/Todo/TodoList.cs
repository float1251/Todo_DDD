using System.Collections.Generic;

namespace TodoApp.Domain.Todo
{
    public class TodoList
    {
        public TodoListId id { get; }
        public string name { get; private set; }
        public IEnumerable<Todo> tasks { get; } = new List<Todo>();

        public TodoList(string name)
        {
            // TODO: ドメインのルールを記述する.最大文字数など...
            this.id = new TodoListId();
            this.name = name;
        }
    }

    public class TodoListId
    {
        public string id { get; } = System.Guid.NewGuid().ToString();
    }
    
}