using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWpf
{
    interface IDialogService
    {
        bool ShowDialog(string name, ViewModel viewModel = null);
    }
}
