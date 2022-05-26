using System.Windows;
using MedicationManager.UI.Core.ViewModels;

namespace MedicationManager.UI.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        public StartWindow(StartWindowViewModel viewModel) : this() 
        {
            DataContext = viewModel;
        }
    }
}
