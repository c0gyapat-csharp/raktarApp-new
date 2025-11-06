using System.Collections.ObjectModel;
using RaktarAppShared.Models;
namespace Desktop.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private ObservableCollection<Warehouse> _warehouses = new ObservableCollection<Warehouse>();
        public ObservableCollection<Warehouse> Warehouses
        {
            get => _warehouses;
            set => SetProperty(ref _warehouses, value);
        }

        private Warehouse? _selectedWarehouse;
        public Warehouse? SelectedWarehouse
        {
            get => _selectedWarehouse;
            set => SetProperty(ref _selectedWarehouse, value);
        }

        public MainWindowViewModel()
        {
            // Sample data — replace this with an API call to your backend:
            Warehouses.Add(new Warehouse { Id = 1, Name = "Central", Country = "HU", Region = "Közép", PostCode = 1000, City = "Budapest", Address = "Main st 1" });
            Warehouses.Add(new Warehouse { Id = 2, Name = "Warehouse B", Country = "HU", Region = "Nyugat", PostCode = 2000, City = "Győr", Address = "Second st 2" });
            Warehouses.Add(new Warehouse { Id = 3, Name = "Depot", Country = "HU", Region = "Dél", PostCode = 3000, City = "Pécs", Address = "Depot rd 3" });

            // Select first by default:
            SelectedWarehouse = Warehouses.Count > 0 ? Warehouses[0] : null;
        }
    }
}