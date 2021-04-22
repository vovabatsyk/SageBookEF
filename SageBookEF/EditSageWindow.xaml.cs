using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SageBookEF.model;

namespace SageBookEF
{
    /// <summary>
    /// Interaction logic for EditSageWindow.xaml
    /// </summary>
    public partial class EditSageWindow : Window
    {
        public EditSageWindow()
        {
            InitializeComponent();
            GetSages();
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            Sage sage = ((FrameworkElement)sender).DataContext as Sage;
            TextBoxName.Text = sage.Name;
            TextBoxAge.Text = sage.Age.ToString();
            TextBoxId.Text = sage.Id.ToString();
            ButtonSave.IsEnabled = true;

        }

        private void GetSages()
        {
            using (MyDbContext context = new MyDbContext())
            {
                var sages = context.Sages.ToList();
                DataGridSages.DataContext = sages;
            }
        }


        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            using (MyDbContext context = new MyDbContext())
            {
                var id = Convert.ToInt32(TextBoxId.Text);
                var sage = context.Sages.FirstOrDefault(x => x.Id == id);
                sage.Name = TextBoxName.Text;
                sage.Age = Convert.ToInt32(TextBoxAge.Text);
                context.SaveChanges();
            }

            TextBoxId.Text = String.Empty;
            TextBoxName.Text = String.Empty;
            TextBoxAge.Text = String.Empty;
            ButtonSave.IsEnabled = false;
            GetSages();
        }
    }
}
