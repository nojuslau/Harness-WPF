using Harness_WPF.Domain.Entities;
using Harness_WPF.Services;
using System.Windows;

namespace Harness_WPF.Views
{
    public partial class MainWindow : Window
    {
        private readonly IService<HarnessDrawing> _drawingService;

        public MainWindow(IService<HarnessDrawing> drawingService)
        {
            _drawingService = drawingService;
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                var data = await _drawingService.GetDataAsync();
                MessageBox.Show($"Data loaded successfully.");
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
