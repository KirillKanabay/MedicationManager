using System;
using System.Windows.Controls;
using MedicationManager.UI.Core.ViewModels.Medications;
using MedicationControlViewModel = MedicationManager.UI.Core.ViewModels.Medications.MedicationControlViewModel;


namespace MedicationManager.UI.Views
{
    /// <summary>
    /// Interaction logic for MedicationView.xaml
    /// </summary>
    public partial class MedicationsControlView : UserControl
    {
        public MedicationsControlView()
        {
            InitializeComponent();
        }

        public MedicationsControlView(MedicationControlViewModel medicationControlViewModel) : this()
        {
            DataContext = medicationControlViewModel ?? throw new ArgumentNullException(nameof(medicationControlViewModel));
        }
    }
}
