using System.Windows;

namespace SageBookEF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void SageAdd_OnClick(object sender, RoutedEventArgs e)
        {
            SageAddWindow window = new SageAddWindow();
            window.ShowDialog();
        }

        private void ShowSages_OnClick(object sender, RoutedEventArgs e)
        {
            ShowSages sages = new ShowSages();
            sages.ShowDialog();
        }

        private void DeleteSage_OnClick(object sender, RoutedEventArgs e)
        {
            DeleteSageWindow window = new DeleteSageWindow();
            window.ShowDialog();
        }

        private void SageEdit_OnClick(object sender, RoutedEventArgs e)
        {
            EditSageWindow window = new EditSageWindow();
            window.ShowDialog();
        }
    }
}
