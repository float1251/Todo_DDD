using TodoApp.Domain.Todo;

namespace TodoApp.Usecase.Todo.DTO
{
    public class TodoDto
    {
        public string id { get; }
        public string name { get; }
        public bool done { get; }

        public TodoDto(string id, string name, bool done)
        {
            this.id = id;
            this.name = name;
            this.done = done;
        }
    }
}