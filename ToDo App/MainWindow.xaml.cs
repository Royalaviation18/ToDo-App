using System.Windows;
using TodoApp.Models;
using TodoApp.ViewModels;

namespace TodoApp
{
    public partial class MainWindow : Window
    {
        private readonly TodoViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new TodoViewModel();
            DataContext = _viewModel;
        }

        private void AddTodo_Click(object sender, RoutedEventArgs e)
        {
            var newItem = new TodoItem
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                IsCompleted = false
            };

            _viewModel.AddTodoItem(newItem);

            txtTitle.Text = "";
            txtDescription.Text = "";
        }

        private void DeleteTodo_Click(object sender, RoutedEventArgs e)
        {
            if (todoListView.SelectedItem != null)
            {
                var selectedTodo = (TodoItem)todoListView.SelectedItem;
                _viewModel.RemoveTodoItem(selectedTodo);
            }
        }
    }
}
