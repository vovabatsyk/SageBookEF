using System;
using System.Windows;
using SageBookEF.model;

namespace SageBookEF
{

    public partial class SageAddWindow : Window
    {
        public SageAddWindow()
        {
            InitializeComponent();
        }

        private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void ButtonSave_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using (MyDbContext context = new MyDbContext())
                {
                    var sage = new Sage()
                    {
                        Name = TextBoxName.Text,
                        Age = Convert.ToInt32(TextBoxAge.Text)
                    };

                    context.Sages.Add(sage);
                    context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            this.Close();
        }
    }
}
