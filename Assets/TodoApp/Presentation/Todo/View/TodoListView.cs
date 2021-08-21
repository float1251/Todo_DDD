using System;
using System.Collections.Generic;
using TMPro;
using TodoApp.Usecase.Todo.DTO;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using VContainer;

namespace TodoApp.Presentation.Todo.View
{
    public class TodoListView : MonoBehaviour, ITodoListView
    {
        [SerializeField] private TextMeshProUGUI todoListName;
        [SerializeField] private Button addTaskButton;

        [SerializeField] private RectTransform container;

        public IObservable<string> OnClickAddTask => _onClickAddTaskSubject;
        public IObservable<Tuple<string, bool>> OnChangeTaskStatus => _onChangeTaskStatus;

        [Inject]
        public void Initialize(TaskViewFactory viewFactory)
        {
            _taskViewFactory = viewFactory;
        }

        public void SetUpView(IEnumerable<TodoDto> todos)
        {
            foreach (var todoDto in todos)
            {
                var view = _taskViewFactory.Instantiate(todoDto, container);
                view.OnCheckClicked.Subscribe(v => _onChangeTaskStatus.OnNext(v))
                    .AddTo(this);
                _cachedView.Add(todoDto.id, view);
            }
        }

        public void AddView(TodoDto dto)
        {
            var view = _taskViewFactory.Instantiate(dto, container);
            view.OnCheckClicked
                .Subscribe(v => _onChangeTaskStatus.OnNext(v))
                .AddTo(this);
            _cachedView.Add(dto.id, view);
        }

        public void UpdateView(TodoDto dto)
        {
            _cachedView[dto.id].UpdateView(dto);
        }

        private readonly Subject<string> _onClickAddTaskSubject = new Subject<string>();
        private readonly Subject<Tuple<string, bool>> _onChangeTaskStatus = new Subject<Tuple<string, bool>>();
        private TaskViewFactory _taskViewFactory;
        // uguiの場合、touchしたらtoggleの状態が変わるので不要でした...
        private Dictionary<string, TaskView> _cachedView = new Dictionary<string, TaskView>();

        void Awake()
        {
            addTaskButton.OnClickAsObservable()
                .Subscribe(_ => _onClickAddTaskSubject.OnNext("task"))
                .AddTo(this);
        }
    }

    public interface ITodoListView
    {
        public IObservable<string> OnClickAddTask { get; }
        public IObservable<Tuple<string, bool>> OnChangeTaskStatus { get; }

        void SetUpView(IEnumerable<TodoDto> todos);
        void AddView(TodoDto dto);

        void UpdateView(TodoDto dto);
    }
}