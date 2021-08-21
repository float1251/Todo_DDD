using System.Threading;
using Cysharp.Threading.Tasks;
using TodoApp.Presentation.Todo.View;
using TodoApp.Usecase.Todo;
using VContainer.Unity;

namespace TodoApp.Presentation.Todo
{
    public class TodoListPresenter: IAsyncStartable
    {
        private IGetDefaultTodoListUseCase _getDefaultTodoListUseCase;
        private ITodoListView _todoListView;

        public TodoListPresenter(IGetDefaultTodoListUseCase getDefaultTodoListUseCase, ITodoListView todoListView)
        {
            _getDefaultTodoListUseCase = getDefaultTodoListUseCase;
            _todoListView = todoListView;
        }
        
        public async UniTask StartAsync(CancellationToken cancellation)
        {
            var todoList = await _getDefaultTodoListUseCase.GetDefaultTodoList();
            _todoListView.SetTodoListName(todoList);
        }
    }
}