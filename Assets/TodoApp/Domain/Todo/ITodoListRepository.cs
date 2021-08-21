using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApp.Domain.Todo
{
    public interface ITodoListRepository
    {
        Task CreateTodoList(TodoList todolist);
        
        Task<IEnumerable<TodoList>> FindAll();
        
        Task<TodoList> Find();
        
        Task<Todo> CreateTask(string name);

        Task<Todo> UpdateTask(Todo todo);

        Todo DeleteTask(TodoId todoId);
    }
    
}