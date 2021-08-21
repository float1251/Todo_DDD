namespace TodoApp.Domain.Todo
{
    public class Task
    {
        private TaskId id;
        private string name;
        private TaskStatus status;

        public Task(string name)
        {
            id = new TaskId();
            this.name = name;
            this.status = TaskStatus.UnDone;
        }
    }

    public class TaskId
    {
        public string id { get; }

        public TaskId()
        {
            id = System.Guid.NewGuid().ToString();
        }
    }

    public enum TaskStatus
    {
        UnDone,
        Done
    }
}