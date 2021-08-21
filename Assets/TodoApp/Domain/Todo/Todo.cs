namespace TodoApp.Domain.Todo
{
    public class Todo
    {
        private TodoId id;
        private string name;
        private TodoStatus status;

        public Todo(string name)
        {
            id = new TodoId();
            this.name = name;
            this.status = TodoStatus.UnDone;
        }
    }

    public class TodoId
    {
        public string id { get; }

        public TodoId()
        {
            id = System.Guid.NewGuid().ToString();
        }
    }

    public enum TodoStatus
    {
        UnDone,
        Done
    }
}