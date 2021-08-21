using System.Threading.Tasks;
using TodoApp.Domain.Todo;
using TodoApp.Usecase.Todo.DTO;
using Task = System.Threading.Tasks.Task;

namespace TodoApp.Usecase.Todo
{
    
    public class GetDefaultUseCase: IGetDefaultTodoListUseCase
    {
        private readonly ITodoListRepository _repository;

        public GetDefaultUseCase(ITodoListRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<TodoListDto> GetDefaultTodoList()
        {
            var res = await _repository.Find();
            return new TodoListDto(res.name);
        }
    }
}