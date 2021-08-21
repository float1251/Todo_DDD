using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using TodoApp.Presentation.Todo.View;
using TodoApp.Usecase.Todo;
using UniRx;
using VContainer.Unity;

namespace TodoApp.Presentation.Todo
{
    public class TodoListPresenter: IInitializable, IAsyncStartable, IDisposable
    {
        private IGetDefaultTodoListUseCase _getDefaultTodoListUseCase;
        private ITodoListView _todoListView;
        readonly CompositeDisposable disposable = new CompositeDisposable();


        public TodoListPresenter(IGetDefaultTodoListUseCase getDefaultTodoListUseCase, ITodoListView todoListView)
        {
            _getDefaultTodoListUseCase = getDefaultTodoListUseCase;
            _todoListView = todoListView;
        }
        
        public void Initialize()
        {

        }
        
        public async UniTask StartAsync(CancellationToken cancellation)
        {
            var todoList = await _getDefaultTodoListUseCase.GetDefaultTodoList();
            _todoListView.SetTodoListName(todoList);
            _todoListView.OnClickAddTask.Subscribe(taskName =>
            {
            }).AddTo(disposable);
        }

        public void Dispose()
        {
            disposable.Dispose();
        }


    }
}