using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWpf
{
    class Company : Entity
    {
        private string title;
        private DateTime creationDate;
        private string address;

        public Company()
        {
            Departments = new ObservableCollection<Department>();
            CreationDate = DateTime.Today;
        }

        public string Title { get => title; set => Set(ref title, value); }
        public DateTime CreationDate { get => creationDate; set => Set(ref creationDate, value); }
        public string Address { get => address; set => Set(ref address, value); }
        public ObservableCollection<Department> Departments { get; set; }
    }
}
