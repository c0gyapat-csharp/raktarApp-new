using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop.Views;
using RaktarAppShared.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;

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

        private object _currentView;

        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
         } 

        public Warehouse? SelectedWarehouse
        {
            get => _selectedWarehouse;
            set
            {
                SetProperty(ref _selectedWarehouse, value);
                CurrentView = value;
            }
        }

        public MainWindowViewModel()
        {
            _ = LoadWarehousesAsync();
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
                    Warehouses = new ObservableCollection<Warehouse>(warehouses);
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

        [RelayCommand]
        private void ShowEditWarehouseView()
        {
            CurrentView = new EditWarehouseViewModel(
                SelectedWarehouse!,
                async () => {
                    await LoadWarehousesAsync();
                    CurrentView = SelectedWarehouse;
                },
                () => {
                    CurrentView = SelectedWarehouse;
                }
            );
        }


        [RelayCommand]
        private void ShowAddWarehouseView()
        {
            CurrentView = new AddWarehouseViewModel(
                async () => {
                    await LoadWarehousesAsync();
                    CurrentView = this;
                },
                () => {
                    CurrentView = this;
                }
            );
        }
    }
    
}