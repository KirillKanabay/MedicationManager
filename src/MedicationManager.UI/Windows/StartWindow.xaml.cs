using System.Windows;
using System.Windows.Input;
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

            HeaderPanel.MouseDown += (s, e) =>
            {
                if (WindowState == WindowState.Maximized)
                {
                    WindowState = WindowState.Normal;
                }
                DragWindow(s, e);
            };
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == 0) { DragMove(); }
        }
    }
}
