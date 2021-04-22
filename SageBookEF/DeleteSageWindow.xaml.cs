using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SageBookEF.model;

namespace SageBookEF
{
    /// <summary>
    /// Interaction logic for DeleteSageWindow.xaml
    /// </summary>
    public partial class DeleteSageWindow : Window
    {
        public DeleteSageWindow()
        {
            InitializeComponent();

            LoadData();
        }

        private void DeleteSage_OnClick(object sender, RoutedEventArgs e)
        {
            using (MyDbContext context = new MyDbContext())
            {
                var sage = ComboBoxSages.SelectedItem as Sage;
                var sageToDelete = context.Sages.FirstOrDefault(x => x.Id == sage.Id);
                context.Sages.Remove(sageToDelete);
                context.SaveChanges();
            }
            this.Close();
        }

        private void LoadData()
        {
            using (MyDbContext context = new MyDbContext())
            {
                var sages = context.Sages.ToList();
                ComboBoxSages.DataContext = sages;
                foreach (var sage in sages)
                {
                    ComboBoxSages.Items.Add(new Sage() { Name = sage.Name, Age = sage.Age, Id = sage.Id });
                }
            }
        }

        private void ComboBoxSages_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonDeleteSage.IsEnabled = true;
        }
    }
}
