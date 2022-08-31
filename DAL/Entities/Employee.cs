using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWpf
{
    class Employee : Person
    {
        private string appointment;
        private DateTime employmentDate;
        private decimal salary;
        private Department department;

        public Employee() : base() 
        {
            employmentDate = DateTime.Today;
        }
        public string Appointment { get => appointment; set => Set(ref appointment, value); }
        public DateTime EmploymentDate { get => employmentDate; set => Set(ref employmentDate, value); }
        public decimal Salary { get => salary; set => Set(ref salary, value); }
        [InverseProperty("Employees")]
        public virtual Department Department { get => department; set => Set(ref department, value); }
    }
}
