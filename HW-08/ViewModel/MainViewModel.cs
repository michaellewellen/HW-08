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
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            ChildViewModels = new ObservableCollection<ChildControl>();
        }

        private ObservableCollection<ChildControl> childViewModels;
        public ObservableCollection<ChildControl> ChildViewModels
        {
            get {return childViewModels; }
            set { SetField(ref childViewModels, value); }
        }

        private ChildControl selectedChildViewModel;
        public ChildControl SelectedChildViewModel
        {
            get { return selectedChildViewModel; }
            set { SetField(ref selectedChildViewModel, value); }
        }

        private RelayCommand treeViewDemonstration;
        public RelayCommand TreeViewDemonstration => treeViewDemonstration ?? (treeViewDemonstration = new RelayCommand(
            () =>
            {

                ChildViewModels.Add(new ChildControl("TreeView Demonstration", new TreeViewViewModel()));
                SelectedChildViewModel = ChildViewModels.Last();
            }));

        private RelayCommand dataGridDemonstration;
        public RelayCommand DataGridDemonstration => dataGridDemonstration ?? (dataGridDemonstration = new RelayCommand(
            () =>
            {
                ChildViewModels.Add(new ChildControl("DataGrid Demonstration", new DataGridViewModel()));
                SelectedChildViewModel = ChildViewModels.Last();
            }));

        private RelayCommand mortgageCalculatorDemonstration;
        public RelayCommand MortgageCalculatorDemonstration => mortgageCalculatorDemonstration ?? (mortgageCalculatorDemonstration = new RelayCommand(
            () =>
            {
                ChildViewModels.Add(new ChildControl("GroupView Expander", new MortgageCalculatorViewModel()));
                SelectedChildViewModel = ChildViewModels.Last();
            }));

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
