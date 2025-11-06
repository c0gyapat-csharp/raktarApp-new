using RaktarAppShared.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using CommunityToolkit.Mvvm.Input;

namespace Desktop.ViewModels
{
    public partial class MainWindowViewModel : BaseViewModel
    {
        private ObservableCollection<Warehouse> _warehouses = new ObservableCollection<Warehouse>();
        public ObservableCollection<Warehouse> Warehouses
        {
            get => _warehouses;
            set => SetProperty(ref _warehouses, value);
        }
        HttpClient _client = new HttpClient();

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
                var response = await _client.GetAsync("https://localhost:7019/Warehouse");
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

        [RelayCommand]
        private async Task DeleteWarehouse(Warehouse warehouse)
        {
            MessageBox.Show("asd");

            if (warehouse == null) return;

            if (!warehouse.CanDelete()) MessageBox.Show("Cant delete non-empty warehouse");

            try
            {
                var response = await _client.DeleteAsync($"https://localhost:7019/Warehouse/{warehouse.Id}");
                if (response.IsSuccessStatusCode)
                {
                    Warehouses.Remove(warehouse);
                }
                else
                {
                    MessageBox.Show($"Error deleting warehouse: {await response.Content.ReadAsStringAsync()}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting warehouse: {ex.Message}");
            }
        }
    }
    
}