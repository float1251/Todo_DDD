using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Domain.Todo;

namespace TodoApp.Infrastructure.Todo
{
    public class TodoListRepository: ITodoListRepository
    {
        public TodoListRepository(string path)
        {
            
        }
        
        public Task CreateTodoList(TodoList todolist)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TodoList>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<TodoList> Find()
        {
            throw new System.NotImplementedException();
        }

        public Task<Domain.Todo.Todo> CreateTask(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<Domain.Todo.Todo> UpdateTask(Domain.Todo.Todo todo)
        {
            throw new System.NotImplementedException();
        }

        public Domain.Todo.Todo DeleteTask(TodoId todoId)
        {
            throw new System.NotImplementedException();
        }
    }
}