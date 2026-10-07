using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {


        DateTime currentTime;
        Color userColor = Color.Red;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000; //Timer'ın 1 saniyede bir çalışması için interval ayarlaması
            timer1.Start();

            currentTime = DateTime.Now;

            dtp.Format = DateTimePickerFormat.Time;
            dtp.ShowUpDown = true;



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentTime = currentTime.AddSeconds(1);
                 labelClock.Text = currentTime.ToString("HH:mm:ss"); 

           int hour = currentTime.Hour;

            if (hour >= 23 || hour < 10)
                labelClock.ForeColor = Color.Green;
            else
                labelClock.ForeColor = userColor;

        }
        private void dtp_ValueChanged(object sender, EventArgs e) //DateTimePicker'da seçilen zamanı güncelleme
        {
            currentTime = dtp.Value;
        }

        private void btnRenk_Click(object sender, EventArgs e) //Renk seçme butonu
        {

            if (colorDialog1.ShowDialog() == DialogResult.OK)   userColor = colorDialog1.Color;
          

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
                if (!string.IsNullOrWhiteSpace(txtZoneName.Text)) {
                    string entry = $"{txtZoneName.Text} ({numDifference.Value})";
                    checkedListBox.Items.Add(entry);
                    comboBox.Items.Add(entry);
                }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (checkedListBox.SelectedIndex != -1 && comboBox.SelectedItem != null) {
                checkedListBox.Items[checkedListBox.SelectedIndex] = comboBox.SelectedItem.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = checkedListBox.CheckedIndices.Count - 1; i >= 0; i--) {
                int index = checkedListBox.CheckedIndices[i];
                object itemToRemove = checkedListBox.Items[index];

            
                if (comboBox.Items.Contains(itemToRemove)){
                    comboBox.Items.Remove(itemToRemove);
                }

      
                checkedListBox.Items.RemoveAt(index);
            }

    
            if (comboBox.Items.Count == 0){
                comboBox.Text = "";
            }
            else{
                comboBox.SelectedIndex = 0; 
            }
        }
        private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBox.CheckedItems.Count > 1)
                btnGuncelle.Enabled = false;
            else
                btnGuncelle.Enabled = true;
        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
        
            int count = checkedListBox.CheckedItems.Count + (e.NewValue == CheckState.Checked ? 1 : -1);

            if (count == 1)    btnGuncelle.Enabled = true;
            else btnGuncelle.Enabled = false;
            
        }
    }
}