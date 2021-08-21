using TodoApp.Presentation.Todo;
using TodoApp.Presentation.Todo.View;
using TodoApp.Usecase.Todo;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace TodoApp.Main
{
    public class TodoLifeTimeScope : LifetimeScope
    {
        [SerializeField] private TodoListView todoListView;
    
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<TodoListPresenter>();
            builder.Register<IGetDefaultTodoListUseCase, GetDefaultUseCase>(Lifetime.Transient);
            builder.RegisterInstance<ITodoListView>(todoListView);
        }
    }
}
