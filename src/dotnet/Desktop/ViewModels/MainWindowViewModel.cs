using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
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
            _ = LoadWarehousesAsync();

            // Select first by default:
            SelectedWarehouse = Warehouses.Count > 0 ? Warehouses[0] : null;
        }

        private async Task LoadWarehousesAsync()
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync("https://localhost:7019/Warehouse");
                response.EnsureSuccessStatusCode();
                var warehouses = await response.Content.ReadFromJsonAsync<List<Warehouse>>();

                if (warehouses != null)
                {
                    Warehouses.Clear();
                    foreach (var warehouse in warehouses)
                    {
                        Warehouses.Add(warehouse);
                    }
                }

            }
            catch (Exception ex)
            {
                // Log/handle error appropriately (Debug.WriteLine, logger, message to user, etc.)
                System.Diagnostics.Debug.WriteLine($"Failed to load warehouses: {ex}");
            }
        }
    }
        
}