using System.Threading.Tasks;
using TodoApp.Usecase.Todo.DTO;

namespace TodoApp.Usecase.Todo
{
    public interface IGetDefaultTodoListUseCase
    {
        Task<TodoListDto> GetDefaultTodoList();
    }
}