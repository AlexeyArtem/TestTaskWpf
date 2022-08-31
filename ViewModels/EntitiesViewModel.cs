using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace TestTaskWpf
{
    abstract class EntitiesViewModel<T> : ViewModel where T : Entity, new()
    {
        protected ICommand loadDataCommand;
        protected ICommand addNewItemCommand;
        protected ICommand updateItemCommand;
        protected ICommand removeItemCommand;
        protected IRepository<T> repository;
        protected ObservableCollection<T> collection;
        protected CollectionViewSource collectionViewSource;

        protected T selectedItem;

        public EntitiesViewModel(IRepository<T> repository)
        {
            this.repository = repository;
        }
        public EntitiesViewModel() { }

        public virtual ICommand AddNewItemCommand
        {
            get
            {
                if (addNewItemCommand == null)
                    addNewItemCommand = new Command(AddNewItem);
                return addNewItemCommand;
            }
        }

        public virtual ICommand LoadDataCommand 
        {
            get 
            {
                if (loadDataCommand == null)
                    loadDataCommand = new Command(LoadData);
                return loadDataCommand;
            }
        }
        public virtual ICommand RemoveItemCommand 
        {
            get 
            {
                if (removeItemCommand == null)
                    removeItemCommand = new Command(RemoveItem);
                return removeItemCommand;
            }
        }
        public virtual ICommand UpdateItemCommand 
        {
            get 
            {
                if (updateItemCommand == null)
                    updateItemCommand = new Command(UpdateItem);
                return updateItemCommand;
            }
        }
        public virtual T SelectedItem { get => selectedItem; set => Set(ref selectedItem, value); }
        public virtual ICollectionView CollectionView => collectionViewSource?.View;
        public virtual ObservableCollection<T> Collection 
        {
            get => collection;
            set
            {
                if (Set(ref collection, value)) 
                {
                    collectionViewSource = new CollectionViewSource() { Source = value };
                    collectionViewSource.View.Refresh();
                    OnPropertyChanged(nameof(CollectionView));
                }
            }
        }

        protected virtual async void LoadData(object parameter)
        {
            await LoadDataAsync();
        }

        protected virtual void AddNewItem(object itemObj) 
        {
            if (itemObj is T item) 
            {
                repository?.Add(item);
                collection?.Add(item);
            }
        }

        protected virtual void UpdateItem(object itemObj) 
        {
            if (itemObj is T item) 
            {
                repository?.Update(item);
                CollectionView?.Refresh();
            }
        }

        protected virtual void RemoveItem(object itemObj) 
        {
            if (itemObj is T itemToRemove) 
            {
                collection?.Remove(itemToRemove);
                repository?.Remove(itemToRemove.Id);
            }
        }

        public virtual async Task LoadDataAsync()
        {
            Collection = new ObservableCollection<T>(await repository.Items.ToListAsync());
        }
    }
}
