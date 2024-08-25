using Harness_WPF.Domain.Entities;
using Harness_WPF.Domain.ViewModels;
using Harness_WPF.Repositories;
using Harness_WPF.Services;
using Microsoft.Extensions.Configuration;
using System.Windows;

namespace Harness_WPF.Views
{
    public partial class MainWindow : Window
    {
        private readonly DrawingService _drawingService;

        public MainWindow(DrawingService drawingService)
        {
            InitializeComponent();
            _drawingService = drawingService;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var data = _drawingService.GetData<HarnessDrawing>();

                //harnessWires = await _repository.GetAllAsync<HarnessWires>();
                //_harnessDrawings = await _repository.GetAllAsync();
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
