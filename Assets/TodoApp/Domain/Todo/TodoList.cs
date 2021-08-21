using System.Collections.Generic;

namespace TodoApp.Domain.Todo
{
    public class TodoList
    {
        public string id { get; }
        public string name { get; private set; }
        public IEnumerable<Task> tasks { get; } = new List<Task>();

        public TodoList(string name)
        {
            // TODO: ドメインのルールを記述する.最大文字数など...
            this.id = System.Guid.NewGuid().ToString();
            this.name = name;
        }
    }
}