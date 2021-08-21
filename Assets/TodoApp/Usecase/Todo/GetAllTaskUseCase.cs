using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Domain.Todo;
using TodoApp.Usecase.Todo.DTO;
using UnityEditor.Rendering;

namespace TodoApp.Usecase.Todo
{
    public interface IGetAllTaskUseCase
    {
        Task<IEnumerable<TodoDto>> GetAllTasks();
    }

    public class GetAllTaskUseCase : IGetAllTaskUseCase
    {
        private ITodoRepository _todoRepository;

        public GetAllTaskUseCase(ITodoRepository repository)
        {
            _todoRepository = repository;
        }

        public async Task<IEnumerable<TodoDto>> GetAllTasks()
        {
            var res = await _todoRepository.FindAll();
            return res.Select(v => new TodoDto(v.id.id, v.name, v.status == TodoStatus.Done));
        }
    }
}