
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW_08.ViewModel
{
    public class TreeViewViewModel : INotifyPropertyChanged
    {



        //public TreeViewViewModel()
        //{ }

        //public TreeViewViewModel(ObservableCollection<Relative> family)
        //{
        //    Family = family;
        //    SelectedRelative = Family?.FirstOrDefault();
        //}

        //public ObservableCollection<Relative> Family { get; }

        //private Relative selectedRelative;
        //public Relative SelectedRelative
        //{
        //    get { return selectedRelative; }
        //    set { SetField(ref selectedRelative, value); }
        //}

        //private RelayCommand addRelative;
        //public RelayCommand AddRelative => addRelative ?? (addRelative = new RelayCommand(
        //    () => SelectedRelative.Children.Add(new Relative("Joe","Blow") )));

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
