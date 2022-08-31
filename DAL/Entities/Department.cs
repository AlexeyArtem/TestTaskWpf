using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWpf
{
    class Department : Entity
    {
        private string title;
        private Employee manager;
        private Company company;

        public Department()
        {
            Employees = new ObservableCollection<Employee>();
        }

        public string Title { get => title; set => Set(ref title, value); }
        public Employee Manager { get => manager; set => Set(ref manager, value); }
        public Company Company { get => company; set => Set(ref company, value); }
        public ObservableCollection<Employee> Employees { get; set; }
    }
}
