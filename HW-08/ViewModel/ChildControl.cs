using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_08.ViewModel
{
    public class ChildControl
    {
        public ChildControl(string header, object viewModel)
        {
            Header = header;
            ViewModel = viewModel;
        }
        public string Header { get; set; }
        public object ViewModel { get; set; }
    }
}
