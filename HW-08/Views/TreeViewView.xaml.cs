using HW_08.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HW_08.Views
{
    /// <summary>
    /// Interaction logic for TreeViewView.xaml
    /// </summary>
    public partial class TreeViewView : UserControl
    {
        public TreeViewView()
        {
            InitializeComponent();
        }

        //private void selectedRelative(object sender, RoutedPropertyChangedEventArgs<object> e)
        //{
        //    var vm = DataContext as TreeViewViewModel;
        //    if (vm != null)
        //        vm.SelectedRelative = e.NewValue as Relative;
        //}
    }
}
