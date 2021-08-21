using System.IO;
using TodoApp.Domain.Todo;
using TodoApp.Infrastructure.Todo;
using TodoApp.Presentation.Todo;
using TodoApp.Presentation.Todo.View;
using TodoApp.Usecase.Todo;
using TodoApp.Usecase.Todo.DTO;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace TodoApp.Main
{
    public class TodoLifeTimeScope : LifetimeScope
    {
        [SerializeField] private TodoListView todoListView;

        [SerializeField] private TaskView taskViewPrefab;
    
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<TodoListPresenter>();
            builder.RegisterInstance<ITodoListView>(todoListView);
            var repo = new TodoRepository(Path.Combine(Application.persistentDataPath, "test.db"));
            builder.RegisterInstance<ITodoRepository>(repo);
            builder.Register<IAddTaskUseCase, AddTaskUseCase>(Lifetime.Scoped);
            builder.Register<IGetAllTaskUseCase, GetAllTaskUseCase>(Lifetime.Scoped);
            builder.Register<IUpdateTaskUseCase, UpdateTaskUseCase>(Lifetime.Scoped);
            var factory = new TaskViewFactory(taskViewPrefab);
            builder.RegisterInstance<TaskViewFactory>(factory);

        }
    }
}
