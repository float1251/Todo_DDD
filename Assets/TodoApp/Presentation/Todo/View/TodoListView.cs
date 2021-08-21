using TMPro;
using TodoApp.Usecase.Todo.DTO;
using UnityEngine;

namespace TodoApp.Presentation.Todo.View
{
    public class TodoListView: MonoBehaviour , ITodoListView
    {
        [SerializeField] private TextMeshProUGUI todoListName;
        public void SetTodoListName(TodoListDto todoList)
        {
            todoListName.text = todoList.name;
        }
    }

    public interface ITodoListView
    {
        void SetTodoListName(TodoListDto todoList);
    }
    
}