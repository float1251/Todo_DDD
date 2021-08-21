using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoApp.Domain.Todo
{
    public interface ITodoListRepository
    {
        Task<IEnumerable<TodoList>> FindAll();
        
        Task<TodoList> Find();

        Task<Task> CreateTask(string name);

        Task<Task> UpdateTask(Task task);

        Task DeleteTask(TaskId taskId);
    }

}