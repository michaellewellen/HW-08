
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
    //public class TreeViewViewModel : INotifyPropertyChanged
    //{
    //    public TreeViewViewModel(ObservableCollection<Person> people)
    //    {
    //        People = people;
    //        SelectedPerson = People?.FirstOrDefault();
    //    }

    //    public ObservableCollection<Person> People { get; }

    //    private String firstName;
    //    public String FirstName
    //    {
    //        get { return firstName; }
    //        set { SetField(ref firstName,value); }
    //    }

    //    private String lastName;
    //    public String LastName
    //    {
    //        get { return lastName; }
    //        set { SetField(ref lastName, value); }
    //    }

    //    private String name;
    //    public String Name
    //    {
    //        get { return name; }
    //        set { SetField(ref name, value); }
    //    }


    //    private Person selectedPerson;
    //    public Person SelectedPerson
    //    {
    //        get { return selectedPerson; }
    //        set { SetField(ref selectedPerson, value); }
    //    }
    //    int childNumber = 1;
    //    private RelayCommand addSinglePerson;
    //    public RelayCommand AddSinglePerson => addSinglePerson ?? (addSinglePerson = new RelayCommand(
    //        () => SelectedPerson.Children.Add(new Person() { FirstName = Name })));

    //    #region INotifyPropertyChanged Implementation
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    //    {
    //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //    }

    //    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    //    {
    //        if (EqualityComparer<T>.Default.Equals(field, value))
    //            return false;
    //        field = value;
    //        OnPropertyChanged(propertyName);
    //        return true;
    //    }
    //    #endregion

    //}

}
