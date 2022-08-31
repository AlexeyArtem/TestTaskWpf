using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWpf
{
    class EmployeeViewModel : ViewModel
    {
        private Employee editableObject;

        public EmployeeViewModel(Employee employee)
        {
            editableObject = employee;

            Id = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname;
            Patronymic = employee.Patronymic;
            Appointment = employee.Appointment;
            BirthDate = employee.BirthDate;
            EmploymentDate = employee.EmploymentDate;
            Department = employee.Department;
            Salary = employee.Salary;
        }

        public EmployeeViewModel() : this(new Employee()) { }

        public int Id
        {
            get => editableObject.Id;
            private set 
            {
                editableObject.Id = value;
                OnPropertyChanged();
            }
        }
        public string Name 
        {
            get => editableObject.Name;
            set
            {
                editableObject.Name = value;
                OnPropertyChanged();
            }
        }
        public string Surname
        {
            get => editableObject.Surname;
            set
            {
                editableObject.Surname = value;
                OnPropertyChanged();
            }
        }
        public string Patronymic
        {
            get => editableObject.Patronymic;
            set
            {
                editableObject.Patronymic = value;
                OnPropertyChanged();
            }
        }
        public string Appointment
        {
            get => editableObject.Appointment;
            set
            {
                editableObject.Appointment = value;
                OnPropertyChanged();
            }
        }
        public DateTime BirthDate
        {
            get => editableObject.BirthDate;
            set
            {
                editableObject.BirthDate = value;
                OnPropertyChanged();
            }
        }
        public DateTime EmploymentDate
        {
            get => editableObject.EmploymentDate;
            set
            {
                editableObject.EmploymentDate = value;
                OnPropertyChanged();
            }
        }
        public Department Department
        {
            get => editableObject.Department;
            set
            {
                editableObject.Department = value;
                OnPropertyChanged();
            }
        }
        public decimal Salary
        {
            get => editableObject.Salary;
            set
            {
                editableObject.Salary = value;
                OnPropertyChanged();
            }
        }
        public Employee EditableObject { get => editableObject; set => Set(ref editableObject, value); }
    }
}
