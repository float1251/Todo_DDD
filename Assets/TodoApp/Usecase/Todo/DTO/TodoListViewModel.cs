using TodoApp.Domain.Todo;

namespace TodoApp.Usecase.Todo.DTO
{
    public class TodoListDto
    {
        public string name { get; private set; }

        public TodoListDto(string name)
        {
            this.name = name;
        }
    }

    public class TaskDto
    {
        public string id { get; }
        public string name { get; }
        public bool done { get; }

        public TaskDto(string id, string name, bool done)
        {
            this.id = id;
            this.name = name;
            this.done = done;
        }
    }

    public class TodoListDtoTranslator
    {
        TodoListDto Translate(TodoList todoList)
        {
            return null;
        } 
    }
}