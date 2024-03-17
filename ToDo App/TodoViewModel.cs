using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using TodoApp.Models;

namespace TodoApp.ViewModels
{
    public class TodoViewModel
    {
        private const string FilePath = "todoList.json";

        public ObservableCollection<TodoItem> TodoList { get; set; }

        // constructor for the class and initializing it.
        public TodoViewModel()
        {
            TodoList = LoadTodoList();
        }

        public void AddTodoItem(TodoItem item)
        {
            TodoList.Add(item);
            SaveTodoList();
        }

        public void RemoveTodoItem(TodoItem item)
        {
            TodoList.Remove(item);
            SaveTodoList();
        }

        public void SaveTodoList()
        {
            string json = JsonConvert.SerializeObject(TodoList);
            File.WriteAllText(FilePath, json);
        }

        private ObservableCollection<TodoItem> LoadTodoList()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<ObservableCollection<TodoItem>>(json);
            }
            return new ObservableCollection<TodoItem>();
        }
    }
}
