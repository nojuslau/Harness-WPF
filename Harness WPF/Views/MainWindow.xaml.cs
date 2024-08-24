using Harness_WPF.Domain.Entities;
using Harness_WPF.Repositories;
using Microsoft.Extensions.Configuration;
using System.Windows;

namespace Harness_WPF.Views
{
    public partial class MainWindow : Window
    {
        private readonly IConfiguration _configuration;
        private readonly Repository _repository;
        private List<HarnessWires> harnessWires;
        private List<HarnessDrawing> harnessDrawings;

        public MainWindow(Repository repository)
        {
            InitializeComponent();
            _repository = repository;
            LoadDataAsync().ConfigureAwait(false);
        }

        private async Task LoadDataAsync()
        {
            try
            {
                //harnessWires = await _repository.GetAllAsync<HarnessWires>();
                harnessDrawings = await _repository.GetAllAsync();
                MessageBox.Show($"An error occurred while loading data:");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Handle other button clicks here
        }
    }
}
