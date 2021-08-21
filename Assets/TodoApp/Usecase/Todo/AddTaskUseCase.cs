using System.Threading.Tasks;
using TodoApp.Usecase.Todo.DTO;

namespace TodoApp.Usecase.Todo
{
    public class AddTaskUseCase: IAddTaskUseCase
    {
        public async Task<TaskDto> AddTask(string id, string taskName)
        {
            await Task.CompletedTask;
            return new TaskDto(System.Guid.NewGuid().ToString(), "test Task", false);
        }
    }
}