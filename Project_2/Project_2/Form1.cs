using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace InClass5
{
    public partial class Form1 : Form
    {
       
        int toplamSkor = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbResimler.Items.Clear();
            cmbResimler.Items.Add("cat.jpg");
            cmbResimler.Items.Add("dog.jpg");
            cmbResimler.Items.Add("flowers.jpg");
            cmbResimler.SelectedIndex = 0;
        }

        private void ButtonResimSec_Click(object sender, EventArgs e)
        {
  
            pnlSource.Controls.Clear();
            pnlTarget.Controls.Clear();
            toplamSkor = 0;
            lblSkor.Text = "Skor: 0";

            if (cmbResimler.SelectedItem == null) return;

            string resimAdi = cmbResimler.SelectedItem.ToString();
            string yol = Path.Combine(Application.StartupPath, resimAdi);

            if (!File.Exists(yol))
            {
                MessageBox.Show("Resim bulunamadı: " + resimAdi);
                return;
            }

            Image anaResim = Image.FromFile(yol);
            int gen = anaResim.Width / 3;
            int yuk = anaResim.Height / 3;

            List<PictureBox> parcalar = new List<PictureBox>();

           
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Bitmap bmp = new Bitmap(gen, yuk);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(anaResim, new Rectangle(0, 0, gen, yuk),
                                    new Rectangle(j * gen, i * yuk, gen, yuk), GraphicsUnit.Pixel);
                    }

                    PictureBox pb = new PictureBox
                    {
                        Image = bmp,
                        Size = new Size(pnlSource.Width / 4, pnlSource.Width / 4),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Tag = i + "," + j

                    };

                    pb.MouseDown += Pb_MouseDown;
                    parcalar.Add(pb);
                }
            }

         
            Random rnd = new Random();
            foreach (var p in parcalar.OrderBy(x => rnd.Next()))
            {
                pnlSource.Controls.Add(p);
            }

      
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Panel hucre = new Panel
                    {
                        Dock = DockStyle.Fill,
                        Tag = i + "," + j,
                        BorderStyle = BorderStyle.FixedSingle,
                        AllowDrop = true
                    };
                    hucre.DragEnter += (s, ev) => ev.Effect = DragDropEffects.Move; 
                    hucre.DragDrop += Hucre_DragDrop;
                    pnlTarget.Controls.Add(hucre, j, i);
                }
            }
        }

        private void Pb_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pb.DoDragDrop(pb, DragDropEffects.Move); 
        }

        private void Hucre_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox parca = (PictureBox)e.Data.GetData(typeof(PictureBox));
            Panel hedef = (Panel)sender;

      
            if (parca.Tag.ToString() == hedef.Tag.ToString())
            {
                parca.Dock = DockStyle.Fill;
                hedef.Controls.Add(parca);
                toplamSkor += 10;
            }
            else
            {
                toplamSkor -= 5;
                pnlSource.Controls.Add(parca);
            }
            lblSkor.Text = "Skor: " + toplamSkor;
        }

   
    }
}