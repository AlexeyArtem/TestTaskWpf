using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestTaskWpf
{
    class DialogModule : NinjectModule
    {
        public override void Load()
        {
            Bind<Window>().To<AddCompanyWindow>().Named("AddCompanyDialog");
            Bind<Window>().To<AddDepartmentWindow>().Named("AddDepartmentDialog");
            Bind<Window>().To<AddEmployeeWindow>().Named("AddEmployeeDialog");
        }
    }
}
