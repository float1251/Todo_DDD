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
        
    }

    public class TodoListDtoTranslator
    {
        TodoListDto Translate(TodoList todoList)
        {
            return null;
        } 
    }
}