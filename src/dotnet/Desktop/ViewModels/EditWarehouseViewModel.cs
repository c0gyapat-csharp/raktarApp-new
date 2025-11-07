using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RaktarAppShared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;

namespace Desktop.ViewModels
{
    internal partial class EditWarehouseViewModel: ObservableObject
    {
        [ObservableProperty]
        private Warehouse _warehouse;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _country;

        [ObservableProperty]
        private string _region;

        [ObservableProperty]
        private string _postCode;

        [ObservableProperty]
        private string _city;

        [ObservableProperty]
        private string _address;
        public IAsyncRelayCommand SaveCommand { get; }
        public IRelayCommand CancelCommand { get; }


        private readonly HttpClient _client;

        public EditWarehouseViewModel(Warehouse warehouse, Func<Task> onSave, Action onCancel)
        {
            _client = new HttpClient();
            Warehouse = warehouse;
            Name = warehouse.Name;
            Country = warehouse.Country;
            Region = warehouse.Region;
            PostCode = warehouse.PostCode.ToString();
            City = warehouse.City;
            Address = warehouse.Address;
            SaveCommand = new AsyncRelayCommand(async () =>
            {
                await SaveWarehouseAsync();
                await onSave();
            });
            CancelCommand = new RelayCommand(onCancel);
        }

        private async Task SaveWarehouseAsync()
        {
            
            Warehouse.Name = this.Name;
            Warehouse.Country = this.Country;
            Warehouse.Region = this.Region;
            Warehouse.PostCode = Convert.ToInt32(this.PostCode);
            Warehouse.City = this.City;
            Warehouse.Address = this.Address;

            try
            {
                var response = await _client.PutAsJsonAsync("https://localhost:7019/Warehouse", Warehouse);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving warehouse: {ex.Message}");
            }
        }
    }
}