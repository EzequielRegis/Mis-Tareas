using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TodoApp.Models;

public class TodoItem : INotifyPropertyChanged
{
	private bool _isCompleted;

	public int Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public bool IsCompleted
	{
		get => _isCompleted;
		set
		{
			if (_isCompleted != value)
			{
				_isCompleted = value;
				OnPropertyChanged();
			}
		}
	}
	public DateTime CreatedAt { get; set; } = DateTime.Now;

	public event PropertyChangedEventHandler? PropertyChanged;

	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
