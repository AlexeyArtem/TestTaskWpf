using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestTaskWpf
{
    class CompanyViewModel : ViewModel
    {
        private Company editableObject;
        private ObservableCollection<Department> departments;
        private ICommand addDepartmentCommand;
        private ICommand removeDepartmentCommand;

        public CompanyViewModel(Company company)
        {
            EditableObject = company;

            Id = company.Id;
            Title = company.Title;
            Address = company.Address;
            CreationDate = company.CreationDate;
            Departments = new ObservableCollection<Department>(company.Departments);
        }
        public CompanyViewModel() : this(new Company()) { }

        public int Id 
        {
            get => editableObject.Id;
            private set
            {
                editableObject.Id = value;
                OnPropertyChanged();
            }
        }
        public string Title
        { 
            get => editableObject.Title;
            set 
            {
                editableObject.Title = value;
                OnPropertyChanged();
            } 
        
        }
        public string Address
        {
            get => editableObject.Address;
            set
            {
                editableObject.Address = value;
                OnPropertyChanged();
            }
        }
        public DateTime CreationDate 
        { 
            get => editableObject.CreationDate;
            set 
            {
                editableObject.CreationDate = value;
            }
        }
        public ObservableCollection<Department> Departments { get => departments; set => Set(ref departments, value); }
        public Company EditableObject { get => editableObject; set => Set(ref editableObject, value); }
        public ICommand AddDepartmentCommand 
        {
            get 
            {
                if (addDepartmentCommand == null)
                    addDepartmentCommand = new Command(AddDepartment);
                return addDepartmentCommand;
            }
        }
        public ICommand RemoveDepartmentCommand 
        {
            get
            {
                if (removeDepartmentCommand == null)
                    removeDepartmentCommand = new Command(RemoveDepartment);
                return removeDepartmentCommand;
            }
        }

        private void AddDepartment(object parameter) 
        {
            if (parameter is Department department) 
            {
                departments.Add(department);
                editableObject.Departments.Add(department);
            }
        }

        private void RemoveDepartment(object parameter) 
        {
            if (parameter is Department department)
            {
                departments.Remove(department);
                editableObject.Departments.Remove(department);
            }
        }
    }
}
