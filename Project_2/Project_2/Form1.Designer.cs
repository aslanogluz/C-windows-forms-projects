namespace InClass5
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbResimler = new System.Windows.Forms.ComboBox();
            this.ButtonResimSec = new System.Windows.Forms.Button();
            this.sure = new System.Windows.Forms.Label();
            this.lblSkor = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnlSource = new System.Windows.Forms.TableLayoutPanel();
            this.pnlTarget = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // cmbResimler
            // 
            this.cmbResimler.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbResimler.FormattingEnabled = true;
            this.cmbResimler.ItemHeight = 29;
            this.cmbResimler.Items.AddRange(new object[] {
            "flower.jpg",
            "dog.jpg",
            "cat.jpg"});
            this.cmbResimler.Location = new System.Drawing.Point(32, 19);
            this.cmbResimler.Name = "cmbResimler";
            this.cmbResimler.Size = new System.Drawing.Size(146, 37);
            this.cmbResimler.TabIndex = 0;
            // 
            // ButtonResimSec
            // 
            this.ButtonResimSec.Location = new System.Drawing.Point(214, 19);
            this.ButtonResimSec.Name = "ButtonResimSec";
            this.ButtonResimSec.Size = new System.Drawing.Size(146, 37);
            this.ButtonResimSec.TabIndex = 1;
            this.ButtonResimSec.Text = "Resim Seç";
            this.ButtonResimSec.UseVisualStyleBackColor = true;
            this.ButtonResimSec.Click += new System.EventHandler(this.ButtonResimSec_Click);
            // 
            // sure
            // 
            this.sure.AutoSize = true;
            this.sure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sure.Location = new System.Drawing.Point(464, 12);
            this.sure.Name = "sure";
            this.sure.Size = new System.Drawing.Size(93, 22);
            this.sure.TabIndex = 2;
            this.sure.Text = "Süre: 120 ";
            // 
            // lblSkor
            // 
            this.lblSkor.AutoSize = true;
            this.lblSkor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSkor.Location = new System.Drawing.Point(465, 34);
            this.lblSkor.Name = "lblSkor";
            this.lblSkor.Size = new System.Drawing.Size(67, 22);
            this.lblSkor.TabIndex = 3;
            this.lblSkor.Text = "Skor: 0";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pnlSource
            // 
            this.pnlSource.AllowDrop = true;
            this.pnlSource.ColumnCount = 3;
            this.pnlSource.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlSource.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlSource.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.pnlSource.Location = new System.Drawing.Point(32, 133);
            this.pnlSource.Name = "pnlSource";
            this.pnlSource.RowCount = 3;
            this.pnlSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlSource.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.pnlSource.Size = new System.Drawing.Size(298, 229);
            this.pnlSource.TabIndex = 6;
            // 
            // pnlTarget
            // 
            this.pnlTarget.AllowDrop = true;
            this.pnlTarget.ColumnCount = 3;
            this.pnlTarget.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTarget.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTarget.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.pnlTarget.Location = new System.Drawing.Point(423, 133);
            this.pnlTarget.Name = "pnlTarget";
            this.pnlTarget.RowCount = 3;
            this.pnlTarget.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTarget.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlTarget.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.pnlTarget.Size = new System.Drawing.Size(298, 229);
            this.pnlTarget.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 456);
            this.Controls.Add(this.pnlTarget);
            this.Controls.Add(this.pnlSource);
            this.Controls.Add(this.lblSkor);
            this.Controls.Add(this.sure);
            this.Controls.Add(this.ButtonResimSec);
            this.Controls.Add(this.cmbResimler);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbResimler;
        private System.Windows.Forms.Button ButtonResimSec;
        private System.Windows.Forms.Label sure;
        private System.Windows.Forms.Label lblSkor;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel pnlSource;
        private System.Windows.Forms.TableLayoutPanel pnlTarget;
    }
}

