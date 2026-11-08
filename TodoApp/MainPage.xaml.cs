using TodoApp.Models;
using TodoApp.ViewModels;

namespace TodoApp;

public partial class MainPage : ContentPage
{
	private TodoViewModel ViewModelProxy => (TodoViewModel)BindingContext;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnItemToggled(object? sender, CheckBox e)
	{
		if (sender is CheckBox checkBox && checkBox.CommandParameter is TodoItem item)
		{
			// sincronizar con ViewModel
			ViewModelProxy.ToggleCommand.Execute(item);
		}
	}

	private void OnDeleteClicked(object? sender, EventArgs e)
	{
		if (sender is Button button && button.CommandParameter is TodoItem item)
		{
			ViewModelProxy.DeleteCommand.Execute(item);
		}
	}
}
