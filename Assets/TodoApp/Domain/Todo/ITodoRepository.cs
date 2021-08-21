using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApp.Domain.Todo
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> FindAll();
        
        Task<Todo> CreateTask(string name);

        Task<Todo> UpdateTask(Todo todo);

        Todo DeleteTask(TodoId todoId);
    }
    
}