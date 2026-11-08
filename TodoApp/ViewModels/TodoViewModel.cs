using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TodoApp.Models;

namespace TodoApp.ViewModels;

public class TodoViewModel : INotifyPropertyChanged
{
	private string _newTitle = string.Empty;
	private string _newDescription = string.Empty;
	private int _pendingCount;
	private int _completedCount;

	public ObservableCollection<TodoItem> Todos { get; } = new();

	public string NewTitle
	{
		get => _newTitle;
		set { if (_newTitle != value) { _newTitle = value; OnPropertyChanged(); } }
	}

	public string NewDescription
	{
		get => _newDescription;
		set { if (_newDescription != value) { _newDescription = value; OnPropertyChanged(); } }
	}

	public int PendingCount
	{
		get => _pendingCount;
		set { if (_pendingCount != value) { _pendingCount = value; OnPropertyChanged(); } }
	}

	public int CompletedCount
	{
		get => _completedCount;
		set { if (_completedCount != value) { _completedCount = value; OnPropertyChanged(); } }
	}

	public bool HasTodos => Todos.Count > 0;
	public bool IsEmpty => Todos.Count == 0;

	public ICommand AddCommand { get; }
	public ICommand ToggleCommand { get; }
	public ICommand DeleteCommand { get; }
	public ICommand DeleteCompletedCommand { get; }

	private int _nextId = 1;

	public TodoViewModel()
	{
		AddCommand = new Command(AddTodo, () => !string.IsNullOrWhiteSpace(NewTitle));
		ToggleCommand = new Command<TodoItem>(ToggleTodo);
		DeleteCommand = new Command<TodoItem>(DeleteTodo);
		DeleteCompletedCommand = new Command(DeleteCompleted);

		// Datos de ejemplo
		Todos.Add(new TodoItem { Id = _nextId++, Title = "Estudiar .NET MAUI", Description = "Leer documentación oficial" });
		Todos.Add(new TodoItem { Id = _nextId++, Title = "Probar en Android", Description = "Instalar en MuMu Player", IsCompleted = true });
		UpdateCounts();
	}

	private void AddTodo()
	{
		var item = new TodoItem
		{
			Id = _nextId++,
			Title = NewTitle.Trim(),
			Description = NewDescription.Trim()
		};
		Todos.Insert(0, item);
		NewTitle = string.Empty;
		NewDescription = string.Empty;
		UpdateCounts();
	}

	private void ToggleTodo(TodoItem? item)
	{
		if (item is null) return;
		item.IsCompleted = !item.IsCompleted;
		UpdateCounts();
	}

	private void DeleteTodo(TodoItem? item)
	{
		if (item is null) return;
		Todos.Remove(item);
		UpdateCounts();
	}

	private void DeleteCompleted()
	{
		foreach (var item in Todos.Where(t => t.IsCompleted).ToList())
		{
			Todos.Remove(item);
		}
		UpdateCounts();
	}

	private void UpdateCounts()
	{
		PendingCount = Todos.Count(t => !t.IsCompleted);
		CompletedCount = Todos.Count(t => t.IsCompleted);
		OnPropertyChanged(nameof(HasTodos));
		OnPropertyChanged(nameof(IsEmpty));
		((Command)AddCommand).RaiseCanExecuteChanged();
	}

	public event PropertyChangedEventHandler? PropertyChanged;
	protected void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
