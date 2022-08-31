using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWpf
{
    class Person : Entity
    {
        private string surname;
        private string name;
        private string patronymic;
        private DateTime birthDate;

        public Person() 
        {
            birthDate = DateTime.Today;
        }

        [Required]
        public string Surname { get => surname; set => Set(ref surname, value); }
        [Required]
        public string Name { get => name; set => Set(ref name, value); }
        [Required]
        public string Patronymic { get => patronymic; set => Set(ref patronymic, value); }
        public DateTime BirthDate { get => birthDate; set => Set(ref birthDate, value); }
    }
}
