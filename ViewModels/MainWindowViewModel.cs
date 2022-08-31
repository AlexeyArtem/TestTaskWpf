using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestTaskWpf
{
    class MainWindowViewModel : ViewModel
    {
        private ViewModel currentViewModel;
        private IDialogService dialogService;
        private ICommand showDialogCommand;
        private ICommand showCompanyEditorCommand;
        private ICommand showDepartmentEditorCommand;
        private ICommand showEmployeeEditorCommand;
        private ICommand loadDataCommand;

        public MainWindowViewModel() : this(new DialogService()) { }

        public MainWindowViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            CompaniesViewModel = new CompaniesViewModel();
            DepartmentsViewModel = new DepartmentsViewModel();
            EmployeesViewModel = new EmployeesViewModel();
        }

        public ViewModel CurrentViewModel { get => currentViewModel; private set => Set(ref currentViewModel, value); }
        public CompaniesViewModel CompaniesViewModel { get; private set; }
        public DepartmentsViewModel DepartmentsViewModel { get; private set; }
        public EmployeesViewModel EmployeesViewModel { get; private set; }
        public ICommand ShowDialogCommand
        {
            get 
            {
                if (showDialogCommand == null)
                    showDialogCommand = new Command(ShowDialog);
                return showDialogCommand;
            }
        }
        
        public ICommand ShowCompanyEditorCommand 
        {
            get 
            {
                if (showCompanyEditorCommand == null)
                    showCompanyEditorCommand = new Command(ShowCompanyEditor);
                return showCompanyEditorCommand;
            }
        }
        public ICommand ShowDepartmentEditorCommand
        {
            get 
            {
                if (showDepartmentEditorCommand == null)
                    showDepartmentEditorCommand = new Command(ShowDepartmentEditor);
                return showDepartmentEditorCommand;
            }
        }
        public ICommand ShowEmployeeEditorCommand
        {
            get
            {
                if (showEmployeeEditorCommand == null)
                    showEmployeeEditorCommand = new Command(ShowEmployeeEditor);
                return showEmployeeEditorCommand;
            }
        }
        public ICommand LoadDataCommand
        {
            get
            {
                if (loadDataCommand == null)
                    loadDataCommand = new Command(LoadData);

                return loadDataCommand;
            }
        }

        private void ShowCompanyEditor(object parameter) 
        {
            if (parameter is Company company) 
                CurrentViewModel = new CompanyViewModel(company);
        }

        private void ShowDepartmentEditor(object parameter) 
        {
            if (parameter is Department department)
                CurrentViewModel = new DepartmentViewModel(department);
        }

        private void ShowEmployeeEditor(object parameter)
        {
            if (parameter is Employee employee)
                CurrentViewModel = new EmployeeViewModel(employee);
        }

        private void ShowDialog(object parameter) 
        {
            if (parameter is string name)
            {
                dialogService.ShowDialog(name);
            }
            else if (parameter is object[] array && array.Length >= 2)
            {
                name = array[0] as string;
                ViewModel viewModel = array[1] as ViewModel;
                dialogService.ShowDialog(name, viewModel);
            }
        }

        private async void LoadData(object parameter)
        {
            await CompaniesViewModel.LoadDataAsync();
            await DepartmentsViewModel.LoadDataAsync();
            await EmployeesViewModel.LoadDataAsync();
        }
    }
}
