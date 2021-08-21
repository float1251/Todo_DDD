using System.Threading.Tasks;
using TodoApp.Domain.Todo;
using TodoApp.Usecase.Todo.DTO;

namespace TodoApp.Usecase.Todo
{
    public class AddTaskUseCase: IAddTaskUseCase
    {
        private ITodoRepository _todoRepository;

        public AddTaskUseCase(ITodoRepository repository)
        {
            _todoRepository = repository;
        }
        
        public async Task<TodoDto> AddTask(string taskName)
        {
            var task = await _todoRepository.CreateTask(taskName);
            return new TodoDto(task.id.id, task.name, task.status == TodoStatus.Done);
        }
    }
}