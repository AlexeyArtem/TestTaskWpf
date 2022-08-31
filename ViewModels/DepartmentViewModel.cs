using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TestTaskWpf
{
    class DepartmentViewModel : ViewModel
    {
        private Department editableObject;
        private ObservableCollection<Employee> employees;
        private ICommand addEmployeeCommand;
        private ICommand removeEmployeeCommand;

        public DepartmentViewModel(Department department)
        {
            EditableObject = department;

            Id = department.Id;
            Title = department.Title;
            Manager = department.Manager;
            Company = department.Company;
            Employees = new ObservableCollection<Employee>(department.Employees);
        }
        public DepartmentViewModel() : this(new Department()) { }

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
        public Employee Manager
        {
            get => editableObject.Manager;
            set 
            {
                editableObject.Manager = value;
                OnPropertyChanged();
            }
        }
        public Company Company 
        {
            get => editableObject.Company;
            set 
            {
                editableObject.Company = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Employee> Employees { get => employees; set => Set(ref employees, value); }
        public Department EditableObject { get => editableObject; set => Set(ref editableObject, value); }
        
        public ICommand AddEmployeeCommand
        {
            get
            {
                if (addEmployeeCommand == null)
                    addEmployeeCommand = new Command(AddEmployee);
                return addEmployeeCommand;
            }
        }
        public ICommand RemoveEmployeeCommand
        {
            get
            {
                if (removeEmployeeCommand == null)
                    removeEmployeeCommand = new Command(RemoveEmployee);
                return removeEmployeeCommand;
            }
        }

        private void AddEmployee(object parameter)
        {
            if (parameter is Employee employee)
            {
                employees.Add(employee);
                editableObject.Employees.Add(employee);
            }
        }

        private void RemoveEmployee(object parameter)
        {
            if (parameter is Employee employee)
            {
                employees.Remove(employee);
                editableObject.Employees.Remove(employee);
            }
        }
    }
}
