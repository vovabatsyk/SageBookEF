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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SageBookEF.model;

namespace SageBookEF
{
    /// <summary>
    /// Interaction logic for BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        public BookWindow()
        {
            InitializeComponent();
            GetBooks();
        }

        private void ButtonLoad_OnClick(object sender, RoutedEventArgs e)
        {
            GetBooks();
            ButtonAddOrEdit.Content = "Add";
            LabelMsg.Content = "";
        }

        private void GetBooks()
        {
            using (MyDbContext context = new MyDbContext())
            {
                DataGridBooks.DataContext = context.Books.ToList();
                ClearInputs();
            }
        }

        private void ButtonAddOrEdit_Onclick(object sender, RoutedEventArgs e)
        {
            if ((string)ButtonAddOrEdit.Content == "Add")
            {
                AddBook();
            }
            else
            {
                EditBook();
            }
        }

        private void EditBook()
        {
            using (MyDbContext context = new MyDbContext())
            {
                var bookId = Convert.ToInt32(TextBoxID.Text);
                var book = context.Books.FirstOrDefault(x => x.Id == bookId);
                if (book != null)
                {
                    book.Pages = Convert.ToInt32(TextBoxPages.Text);
                    book.Title = TextBoxTitle.Text;
                }

                context.SaveChanges();
                ClearInputs();
                LabelMsg.Content = "Book was edit successfully";
                ButtonAddOrEdit.Content = "Add";
            }
        }

        private void AddBook()
        {
            using (MyDbContext context = new MyDbContext())
            {
                var book = new Book()
                {
                    Title = TextBoxTitle.Text,
                    Pages = Convert.ToInt32(TextBoxPages.Text)
                };
                context.Books.Add(book);
                context.SaveChanges();
                ClearInputs();
                LabelMsg.Content = "Book Saved Successfully";
            }
        }

        private void ClearInputs()
        {
            TextBoxPages.Text = String.Empty;
            TextBoxTitle.Text = String.Empty;
            TextBoxID.Text = String.Empty;
        }

        private void ButtonEdit_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonAddOrEdit.Content = "Save";
            var book = ((FrameworkElement)sender).DataContext as Book;
            TextBoxID.Text = book.Id.ToString();
            TextBoxPages.Text = book.Pages.ToString();
            TextBoxTitle.Text = book.Title;
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            using (MyDbContext context = new MyDbContext())
            {
                var book = ((FrameworkElement)sender).DataContext as Book;
                context.Books.Remove(context.Books.FirstOrDefault(x=>x.Id == book.Id));
                context.SaveChanges();
                GetBooks();
            }

        }
    }
}
