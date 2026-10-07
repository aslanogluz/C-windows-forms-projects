using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace InClass_7_152120221100_152120231048_Group_10
{
    public partial class Form1 : Form
    {
        private UserService userService = new UserService();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (userService.Register(txtUsername.Text, txtPassword.Text))
                MessageBox.Show("Başarıyla kaydedildi.");
            else
                MessageBox.Show("Kayıt başarısız! Kullanıcı adı mevcut veya boş alan var.");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (userService.Login(txtUsername.Text, txtPassword.Text))
            {
                Form2 dashboard = new Form2(txtUsername.Text);
                dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre!");
            }
        }
    }

    // Kullanıcı işlemleri
    public class UserService
    {
        private const string FilePath = "users.txt";

        public bool Register(string user, string pass)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
                return false;

            if (File.Exists(FilePath) && File.ReadAllLines(FilePath).Any(l => l.Split(';')[0] == user))
                return false;

            File.AppendAllLines(FilePath, new[] { $"{user};{pass}" });
            return true;
        }

        public bool Login(string user, string pass)
        {
            if (!File.Exists(FilePath))
                return false;

            return File.ReadAllLines(FilePath).Any(l => l == $"{user};{pass}");
        }
    }


    public class LibraryService
    {
        public List<BookItem> GetBooks()
        {
            return new List<BookItem>
            {
                new BookItem { Category = "Science", SubCategory = "Physics", Title = "Quantum Theory" },
                new BookItem { Category = "Science", SubCategory = "Physics", Title = "Classical Mechanics" },
                new BookItem { Category = "Science", SubCategory = "Chemistry", Title = "Organic Chemistry" },
                new BookItem { Category = "Technology", SubCategory = "Programming", Title = "C# Programming" },
                new BookItem { Category = "Technology", SubCategory = "Databases", Title = "SQL Basics" },
                new BookItem { Category = "Literature", SubCategory = "Novel", Title = "Modern Novel" }
            };
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class BookItem
    {
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Title { get; set; }
    }

    public class BorrowingRecord
    {
        public string Date { get; set; }
        public string Username { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string BookTitle { get; set; }
    }
}