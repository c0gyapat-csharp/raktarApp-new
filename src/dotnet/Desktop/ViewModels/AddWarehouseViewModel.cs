using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RaktarAppShared.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Desktop.ViewModels
{
    public partial class AddWarehouseViewModel : ObservableObject
    {
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

        public AddWarehouseViewModel(Func<Task> onSave, Action onCancel)
        {
            _client = new HttpClient { BaseAddress = new Uri("https://localhost:7019/Warehouse") };
            SaveCommand = new AsyncRelayCommand(async () =>
            {
                await SaveWarehouseAsync();
                await onSave();
            });
            CancelCommand = new RelayCommand(onCancel);
        }

        private async Task SaveWarehouseAsync()
        {
            var newWarehouse = new Warehouse
            {
                Name = this.Name,
                Country = this.Country,
                Region = this.Region,
                PostCode = Convert.ToInt32(this.PostCode),
                City = this.City,
                Address = this.Address,
                Items = []
            };

            try
            {
                var response = await _client.PostAsJsonAsync("/Warehouse", newWarehouse);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving warehouse: {ex.Message}");
            }
        }
    }
}