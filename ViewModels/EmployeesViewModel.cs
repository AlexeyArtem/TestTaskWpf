using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace TestTaskWpf
{
    class EmployeesViewModel : EntitiesViewModel<Employee>
    {
        private Company companyFilter;
        private int experienceFilter = -1;
        private int birthYearFilter;
        private int ageFilter;
        private TypeAge typeAgeFilter;
        private ICommand resetFiltersCommand;

        public EmployeesViewModel() : base()
        {
            repository = new Repository<Employee>(App.Database);
        }

        public override ObservableCollection<Employee> Collection 
        {
            get => collection;
            set
            {
                if (Set(ref collection, value))
                {
                    collectionViewSource = new CollectionViewSource() { Source = value };
                    collectionViewSource.Filter += OnCompanyFilter;
                    collectionViewSource.Filter += OnExperinceFilter;
                    TypeAgeFilter = TypeAge.NumberYears;
                    collectionViewSource.View.Refresh();
                    OnPropertyChanged(nameof(CollectionView));
                }
            }
        }
        public Company CompanyFilter
        {
            get => companyFilter;
            set
            {
                if (Set(ref companyFilter, value)) 
                {
                    CollectionView?.Refresh();
                }
            }
        }
        public int ExperienceFilter
        {
            get => experienceFilter;
            set
            {
                if (Set(ref experienceFilter, value))
                {
                    CollectionView?.Refresh();
                }
            }
        }
        public int BirthYearFilter 
        {
            get => birthYearFilter;
            set
            {
                if (Set(ref birthYearFilter, value)) 
                {
                    CollectionView?.Refresh();
                }
            }
        }
        public int AgeFilter
        {
            get => ageFilter;
            set
            {
                if (Set(ref ageFilter, value))
                {
                    CollectionView?.Refresh();
                }
            }
        }
        public TypeAge TypeAgeFilter 
        {
            get => typeAgeFilter;
            set 
            {
                typeAgeFilter = value;
                if (typeAgeFilter == TypeAge.NumberYears)
                {
                    collectionViewSource.Filter -= OnBirthYearFilter;
                    collectionViewSource.Filter += OnAgeFilter;
                }
                else
                {

                    collectionViewSource.Filter -= OnAgeFilter;
                    collectionViewSource.Filter += OnBirthYearFilter;
                }
                CollectionView?.Refresh();
                OnPropertyChanged();
            }
        }
        public ICommand ResetFiltersCommand
        {
            get
            {
                if (resetFiltersCommand == null)
                    resetFiltersCommand = new Command(ResetFilters);
                return resetFiltersCommand;
            }
        }

        private void OnCompanyFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Employee employee) || companyFilter == null) return;

            if (employee.Department.Company != companyFilter)
                e.Accepted = false;
        }

        private void OnExperinceFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Employee employee) || experienceFilter < 0) return;

            if (DateTime.Today.Year - employee.EmploymentDate.Year != experienceFilter)
                e.Accepted = false;
        }

        private void OnBirthYearFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Employee employee) || birthYearFilter <= 0) return;

            if (employee.BirthDate.Year != birthYearFilter)
                e.Accepted = false;
        }

        private void OnAgeFilter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Employee employee) || ageFilter <= 0) return;

            if (DateTime.Today.Year - employee.BirthDate.Year != ageFilter)
                e.Accepted = false;
        }

        private void ResetFilters(object parameter) 
        {
            CompanyFilter = null;
            ExperienceFilter = -1;
            BirthYearFilter = 0;
            AgeFilter = 0;
            CollectionView?.Refresh();
        }
    }
}
