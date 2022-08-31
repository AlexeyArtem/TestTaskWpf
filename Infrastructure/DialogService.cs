using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestTaskWpf
{
    class DialogService : IDialogService
    {
        private static readonly IKernel dialogKernel = new StandardKernel(new DialogModule());

        public DialogService() { }

        public bool ShowDialog(string name, ViewModel viewModel = null)
        {
            bool isResolve = dialogKernel.CanResolve<Window>(name);
            if (isResolve)
            {
                Window dialog = dialogKernel.Get<Window>(name);
                if (viewModel != null)
                    dialog.DataContext = viewModel;
                return (bool)dialog.ShowDialog();
            }
            else return false;
        }
    }
}
