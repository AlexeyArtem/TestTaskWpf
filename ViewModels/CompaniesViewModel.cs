using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWpf
{
    class CompaniesViewModel : EntitiesViewModel<Company>
    {
        public CompaniesViewModel() : base()
        {
            repository = new Repository<Company>(App.Database);
        }

        public override async Task LoadDataAsync()
        {
            Collection = new ObservableCollection<Company>(await repository.Items
                .Include(c => c.Departments.Select(d => d.Employees))
                .ToListAsync());
        }
    }
}
