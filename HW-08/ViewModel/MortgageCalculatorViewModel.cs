using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HW_08.ViewModel
{
    public class PizzaViewModel : INotifyPropertyChanged
    {
        public ICommand MyCommand { get; set; }
        public ICommand DrinkCommand { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetField(ref name, value);}
        }

        private string drink;
        public string Drink
        {
            get { return drink; }
            set { SetField(ref drink, value); }
        }

        public PizzaViewModel()
        {
            MyCommand = new RCommand(executemethod, canexecutemethod);
            DrinkCommand = new RCommand(executeDrink, canExecuteDrink);
        }

        private bool canexecutemethod (object parameter)
        {
            if (parameter != null)
                return true;
            else
                return false;
        }

        private void executemethod(object parameter)
        {
            Name = (string)parameter;
        }

        private bool canExecuteDrink (object parameter)
        {
            if (parameter != null)
                return true;
            else
                return false;
        }

        private void executeDrink(object parameter)
        {
            Drink = (string)parameter;
        }
        public class RCommand : ICommand
        {

            Action<object> _executemethod;
            Func<object, bool> _canexecutemethod;

            public RCommand(Action<object> executemethod, Func<object, bool> canexecutemethod)
            {
                _executemethod = executemethod;
                _canexecutemethod = canexecutemethod;
            }


            public bool CanExecute(object parameter)
            {
                if (_canexecutemethod != null)
                {
                    return _canexecutemethod(parameter);
                }
                else
                {
                    return false;
                }
            }

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public void Execute(object parameter)
            {
                _executemethod(parameter);
            }
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
