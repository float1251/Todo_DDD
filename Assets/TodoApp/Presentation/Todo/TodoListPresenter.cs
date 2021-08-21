using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using TodoApp.Presentation.Todo.View;
using TodoApp.Usecase.Todo;
using TodoApp.Usecase.Todo.DTO;
using UniRx;
using VContainer.Unity;

namespace TodoApp.Presentation.Todo
{
    public class TodoListPresenter : IAsyncStartable, IDisposable
    {
        private ITodoListView _todoListView;
        readonly CompositeDisposable disposable = new CompositeDisposable();
        private readonly IAddTaskUseCase _addTaskUseCase;
        private IGetAllTaskUseCase _getAllTaskUseCase;
        private IUpdateTaskUseCase _updateTaskUseCase;

        public TodoListPresenter(ITodoListView todoListView, IAddTaskUseCase addTaskUseCase,
            IGetAllTaskUseCase getAllTaskUseCase, IUpdateTaskUseCase updateTaskUseCase)
        {
            _todoListView = todoListView;
            _addTaskUseCase = addTaskUseCase;
            _getAllTaskUseCase = getAllTaskUseCase;
            _updateTaskUseCase = updateTaskUseCase;
        }

        public async UniTask StartAsync(CancellationToken cancellation)
        {
            _todoListView.OnClickAddTask.Subscribe(async taskName =>
            {
                var task = await this._addTaskUseCase.AddTask(taskName);
                this._todoListView.AddView(task);
            }).AddTo(disposable);

            _todoListView.OnChangeTaskStatus.Subscribe(async v =>
            {
                // TODO:本当は良くないが面倒なため、todoList全件からidで検索する
                var allTasks = await _getAllTaskUseCase.GetAllTasks();
                var targetTodo = allTasks.First(_ => _.id == v.Item1);
                var updateTodo = new TodoDto(targetTodo.id, targetTodo.name, v.Item2);
                var todo = await _updateTaskUseCase.UpdateTask(updateTodo);
                _todoListView.UpdateView(todo); 
            }).AddTo(disposable);

            var todos = await _getAllTaskUseCase.GetAllTasks();
            _todoListView.SetUpView(todos);
        }

        public void Dispose()
        {
            disposable.Dispose();
        }
    }
}