using System.Threading.Tasks;
using TodoApp.Usecase.Todo.DTO;

namespace TodoApp.Usecase.Todo
{
    public class GetDefaultUseCase: IGetDefaultTodoListUseCase
    {
        public async Task<TodoListDto> GetDefaultTodoList()
        {
            await Task.CompletedTask;
            return new TodoListDto("Default Todo List");
        }
    }
}