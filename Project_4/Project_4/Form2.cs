using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace InClass_7_152120221100_152120231048_Group_10
{
    public partial class Form2 : Form
    {
        private string loggedInUser;
        private LibraryService library = new LibraryService();

       
        public Form2(string user)
        {
            InitializeComponent();
            loggedInUser = user;
        }

        
        private void Form2_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {loggedInUser}";

           
            cmbCategory.DataSource = library.GetBooks()
                                            .Select(b => b.Category)
                                            .Distinct()
                                            .ToList();

            cmbSubCategory.Enabled = false;
            cmbBook.Enabled = false;
        }

  


        private void cmbCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var subCats = library.GetBooks()
               .Where(b => b.Category == cmbCategory.Text)
               .Select(b => b.SubCategory)
               .Distinct()
               .ToList();

            cmbSubCategory.DataSource = subCats;
            cmbSubCategory.Enabled = true;
            cmbBook.DataSource = null;
        }

        private void cmbSubCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var books = library.GetBooks()
                .Where(b => b.SubCategory == cmbSubCategory.Text)
                .Select(b => b.Title)
                .ToList();

            cmbBook.DataSource = books;
            cmbBook.Enabled = true;

        }

        private void btnBorrow_Click_1(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedItem == null ||
               cmbSubCategory.SelectedItem == null ||
               cmbBook.SelectedItem == null)
            {
                MessageBox.Show("Lütfen tüm seçimleri yapın!");
                return;
            }

            string record = $"{DateTime.Now:yyyy-MM-dd};{loggedInUser};{cmbCategory.Text};{cmbSubCategory.Text};{cmbBook.Text}";
            File.AppendAllLines("borrowings.txt", new[] { record });
            MessageBox.Show("Kitap ödünç alındı!");
        }

        private void btnHistory_Click_1(object sender, EventArgs e)
        {
            lstHistory.Items.Clear();

            if (!File.Exists("borrowings.txt"))
            {
                MessageBox.Show("Henüz ödünç alınan kitap yok.");
                return;
            }

            var lines = File.ReadAllLines("borrowings.txt")
                .Where(l => l.Split(';')[1] == loggedInUser)
                .Select(l =>
                {
                    var parts = l.Split(';');
                    return $"{DateTime.Parse(parts[0]):dd.MM.yyyy} | {parts[2]} | {parts[4]}";
                });

            foreach (var item in lines)
                lstHistory.Items.Add(item);

        }
    }
}