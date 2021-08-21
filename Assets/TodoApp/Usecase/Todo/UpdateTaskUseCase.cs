using System.Threading.Tasks;
using TodoApp.Domain.Todo;
using TodoApp.Usecase.Todo.DTO;

namespace TodoApp.Usecase.Todo
{
    public interface IUpdateTaskUseCase
    {
        Task<TodoDto> UpdateTask(TodoDto todo);
    }

    public class UpdateTaskUseCase : IUpdateTaskUseCase
    {
        private ITodoRepository _repository;

        public UpdateTaskUseCase(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoDto> UpdateTask(TodoDto todo)
        {
            var status = todo.done ? TodoStatus.Done : TodoStatus.UnDone;
            var res = await _repository.UpdateTask(new Domain.Todo.Todo(new TodoId(todo.id), todo.name, todo.done));
            return new TodoDto(res.id.id, res.name, res.IsDone());
        }
    }
}