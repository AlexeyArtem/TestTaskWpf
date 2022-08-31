using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWpf
{
    class DepartmentsViewModel : EntitiesViewModel<Department>
    {
        public DepartmentsViewModel() : base() 
        {
            repository = new Repository<Department>(App.Database);
        }

        public override async Task LoadDataAsync()
        {
            Collection = new ObservableCollection<Department>(await repository.Items
                .Include(d => d.Employees)
                .ToListAsync());
        }
    }
}
