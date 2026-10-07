using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {

        int elapsedSeconds = 0;
        Timer gameTimer = new Timer();
        int totalMatches = 0;


        private void GameTimer_Tick(object sender, EventArgs e)
        {
            elapsedSeconds++;
            int minutes = elapsedSeconds / 60;
            int seconds = elapsedSeconds % 60;
            lblTime.Text = $"Time: {minutes:D2}:{seconds:D2}";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("3x4");
            comboBox1.Items.Add("3x5");

        }

        List<Image> selectedImages = new List<Image>();
        private void button1_Click(object sender, EventArgs e)
        {

            string selectedSize = comboBox1.SelectedItem?.ToString();

            int requiredCount = 0;
            if (selectedSize == "3x4")
                requiredCount = 4;
           
            else if (selectedSize == "3x5")
                requiredCount = 5;
           
            else
            {
                MessageBox.Show("Lütfen önce matris boyutunu seçiniz (3x4 veya 3x5).");
                return;
            }

   
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "Resimleri Seçiniz";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileNames.Length != requiredCount)
                {
                    MessageBox.Show($"Seçilen boyut için {requiredCount} farklı resim seçmelisiniz!");
                    return;
                }

                selectedImages.Clear();
                foreach (string fileName in ofd.FileNames)
                {
                    Image img = Image.FromFile(fileName);
                    selectedImages.Add(img);
                }

                MessageBox.Show($"{selectedImages.Count} resim başarıyla yüklendi.");
            }
        }


        List<Image> tripledImages = new List<Image>();

        private void PrepareImages()
        {
            tripledImages.Clear();

            foreach (Image img in selectedImages)
            {

                for (int i = 0; i < 3; i++)
                {
                    tripledImages.Add(img);
                }
            }


            Random rnd = new Random();
            tripledImages = tripledImages.OrderBy(x => rnd.Next()).ToList();

            MessageBox.Show($"Toplam {tripledImages.Count} kart hazırlandı.");
        }
        
        Button firstCard = null;
        Button secondCard = null;
        Button thirdCard = null;

       
        int moves = 0;
        int matches = 0;

        private void Card_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            
            if (clickedButton.BackgroundImage != null) return;

           
            clickedButton.BackgroundImage = (Image)clickedButton.Tag;
            clickedButton.BackgroundImageLayout = ImageLayout.Stretch;

           
            if (firstCard == null)
            {
                firstCard = clickedButton;
            }
            else if (secondCard == null)
            {
                secondCard = clickedButton;
            }
            else if (thirdCard == null)
            {
                thirdCard = clickedButton;

                
                moves++;
                lblMoves.Text = $"Moves: {moves}";

               
                if (firstCard.Tag == secondCard.Tag && secondCard.Tag == thirdCard.Tag)
                {
                 
                    firstCard.Enabled = false;
                    secondCard.Enabled = false;
                    thirdCard.Enabled = false;

                
                    matches++;
                    lblMatches.Text = $"Matches: {matches}";

                 
                    firstCard = null;
                    secondCard = null;
                    thirdCard = null;
                }
                else
                {
                   
                    Timer flipBackTimer = new Timer();
                    flipBackTimer.Interval = 800;
                    flipBackTimer.Tick += (s, args) =>
                    {
                        if (firstCard != null) firstCard.BackgroundImage = null;
                        if (secondCard != null) secondCard.BackgroundImage = null;
                        if (thirdCard != null) thirdCard.BackgroundImage = null;

                        flipBackTimer.Stop();
                        flipBackTimer.Dispose();

                        
                        firstCard = null;
                        secondCard = null;
                        thirdCard = null;
                    };
                    flipBackTimer.Start();


                    if (firstCard.Tag == secondCard.Tag && secondCard.Tag == thirdCard.Tag)
                    {
                        firstCard.Enabled = false;
                        secondCard.Enabled = false;
                        thirdCard.Enabled = false;

                        matches++;
                        lblMatches.Text = $"Matches: {matches}";

                    
                        if (matches == totalMatches)
                        {
                            gameTimer.Stop();
                            MessageBox.Show($"Tebrikler, oyun bitti! Süreniz: {elapsedSeconds} saniye");
                        }

                        firstCard = null;
                        secondCard = null;
                        thirdCard = null;
                    }
                }
            }
        }



        private void CreateGameGrid()
        {

            tableLayoutPanel1.Controls.Clear();


            string selectedSize = comboBox1.SelectedItem?.ToString();

            int rows = 0, cols = 3;
            if (selectedSize == "3x4")
                rows = 4;
            else if (selectedSize == "3x5")
                rows = 5;
            else
            {
                MessageBox.Show("Lütfen geçerli bir boyut seçiniz.");
                return;
            }


            tableLayoutPanel1.RowCount = rows;
            tableLayoutPanel1.ColumnCount = cols;

            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            for (int r = 0; r < rows; r++)
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));
            for (int c = 0; c < cols; c++)
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));

            int index = 0;
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Fill;


                    btn.BackColor = Color.LightGray;


                    btn.Tag = tripledImages[index];


                    btn.Click += Card_Click;

                    tableLayoutPanel1.Controls.Add(btn, c, r);

                    index++;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            elapsedSeconds = 0;
            lblTime.Text = "Time: 00:00";

            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

           
            if (comboBox1.SelectedItem.ToString() == "3x4")
                totalMatches = 4;
            else if (comboBox1.SelectedItem.ToString() == "3x5")
                totalMatches = 5;
            PrepareImages();
            CreateGameGrid();

        }

 
    }
}





    

