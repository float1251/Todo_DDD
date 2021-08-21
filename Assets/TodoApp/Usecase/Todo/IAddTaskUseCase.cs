using System.Threading.Tasks;
using TodoApp.Domain.Todo;
using TodoApp.Usecase.Todo.DTO;

namespace TodoApp.Usecase.Todo
{
    public interface IAddTaskUseCase
    {
        Task<TodoDto> AddTask(string taskName);
    }
}