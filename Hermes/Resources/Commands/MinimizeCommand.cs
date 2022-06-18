using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Hermes.Resources.Commands
{
	public class MinimizeCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter) => true;

		public void Execute(object parameter)
		{
			var window = parameter as Window;

			if (window != null)
				window.WindowState = WindowState.Minimized;
		}
	}
}
