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
    public class Relative:INotifyPropertyChanged
    {
        public Relative() : this(firstName: null, lastName: null) { }
        

        public Relative(string firstName=null, string lastName=null)
        {
            FirstName = firstName;
            LastName = lastName;
            FullName = FirstName + " " + LastName;
            Children.CollectionChanged += (s, e) => OnPropertyChanged(nameof(Children));
        }
        private String firstName;
        public String FirstName
        {
            get { return firstName; }
            set { SetField(ref firstName, value); }
        }

        private String lastName;
        public String LastName
        {
            get { return lastName; }
            set { SetField(ref lastName, value); }
        }
        private String fullName;
        public String FullName
        {
            get { return fullName; }
            set { SetField(ref fullName, value); }
        }

        private ObservableCollection<Relative> children;
        public ObservableCollection<Relative> Children => children ?? (children = new ObservableCollection<Relative>());

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
