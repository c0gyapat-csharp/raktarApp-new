using CommunityToolkit.Mvvm.Input;
using RaktarAppShared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;

namespace Desktop.ViewModels
{
    internal class EditWarehouseViewModel
    {
        public IAsyncRelayCommand SaveCommand { get; }
        public IRelayCommand CancelCommand { get; }


        private readonly HttpClient _client;

        public EditWarehouseViewModel(Warehouse warehouse, Func<Task> onSave, Action onCancel)
        {
            _client = new HttpClient { BaseAddress = new Uri("https://localhost:7019/Warehouse") };
            SaveCommand = new AsyncRelayCommand(async () =>
            {
                await SaveWarehouseAsync(warehouse);
                await onSave();
            });
            CancelCommand = new RelayCommand(onCancel);
        }

        private async Task SaveWarehouseAsync(Warehouse warehouse)
        {
            try
            {
                var response = await _client.PutAsJsonAsync("/Warehouse", warehouse);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving warehouse: {ex.Message}");
            }
        }
    }
}