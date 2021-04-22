using System.Linq;
using System.Windows;

namespace SageBookEF
{
    public partial class ShowSages : Window
    {
        public ShowSages()
        {
            InitializeComponent();

            using (MyDbContext context = new MyDbContext())
            {
                var sages = context.Sages.ToList();
                DataGridSages.DataContext = sages;
            }
        }
    }
}
