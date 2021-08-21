using System;
using TMPro;
using TodoApp.Usecase.Todo.DTO;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace TodoApp.Presentation.Todo.View
{
    public class TodoListView: MonoBehaviour , ITodoListView
    {
        [SerializeField] private TextMeshProUGUI todoListName;
        [SerializeField] private Button addTaskButton;

        public IObservable<string> OnClickAddTask => _onClickAddTaskSubject;
        private readonly Subject<string> _onClickAddTaskSubject = new Subject<string>();

        void Awake()
        {
            addTaskButton.OnClickAsObservable()
                .Subscribe(_ => _onClickAddTaskSubject.OnNext("task"))
                .AddTo(this);
        }
        
        public void SetTodoListName(TodoListDto todoList)
        {
            todoListName.text = todoList.name;
        }
    }

    public interface ITodoListView
    {
        public IObservable<string> OnClickAddTask { get; }
        void SetTodoListName(TodoListDto todoList);
    }
    
}