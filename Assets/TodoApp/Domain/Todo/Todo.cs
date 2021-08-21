namespace TodoApp.Domain.Todo
{

    public class Todo
    {
        public TodoId id { get; }
        public string name { get; }
        public TodoStatus status { get; }
        
        public Todo(string name)
        {
            id = new TodoId();
            this.name = name;
            this.status = TodoStatus.UnDone;
        }
        
        public Todo(TodoId id, string name, bool status)
        {
            this.id = id;
            this.name = name;
            this.status = status ? TodoStatus.Done : TodoStatus.UnDone;
        }

        public bool IsDone()
        {
            return status == TodoStatus.Done;
        }
    }

    public class TodoId
    {
        public string id { get; }

        public TodoId()
        {
            id = System.Guid.NewGuid().ToString();
        }

        public TodoId(string id)
        {
            this.id = id;
        }
    }

    public enum TodoStatus
    {
        UnDone,
        Done
    }
}