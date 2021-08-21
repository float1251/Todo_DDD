using System;
using TMPro;
using TodoApp.Usecase.Todo.DTO;
using UniRx;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace TodoApp.Presentation.Todo.View
{
    public interface ITaskView
    {
        void UpdateView(TodoDto data);
    }

    public class TaskViewFactory
    {
        private TaskView _taskView;

        public TaskViewFactory(TaskView prefab)
        {
            _taskView = prefab;
        }

        public TaskView Instantiate(TodoDto dto, Transform parent)
        {
            var view = GameObject.Instantiate<TaskView>(this._taskView, parent);
            view.UpdateView(dto);
            return view;
        }
    }

    public class TaskView : MonoBehaviour, ITaskView
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Toggle check;

        public IObservable<Tuple<string, bool>> OnCheckClicked => _toggleSubject;
        private readonly Subject<Tuple<string, bool>> _toggleSubject = new Subject<Tuple<string, bool>>();

        private string id;

        private void Awake()
        {
            check.OnValueChangedAsObservable()
                .Subscribe(_ => _toggleSubject.OnNext(new Tuple<string, bool>(this.id, _)))
                .AddTo(this);
        }

        public void UpdateView(TodoDto data)
        {
            this.id = data.id;
            text.text = data.name;
            check.isOn = data.done;
        }
    }
}