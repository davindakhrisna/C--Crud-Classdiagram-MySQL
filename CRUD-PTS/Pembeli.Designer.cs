namespace CRUD_PTS
{
    partial class Pembeli
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label5 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            txtuang = new TextBox();
            btnKonfirmasi = new Button();
            label4 = new Label();
            label3 = new Label();
            datePicker = new DateTimePicker();
            cmbJenis = new ComboBox();
            txtNama = new TextBox();
            rtbNota = new RichTextBox();
            label2 = new Label();
            dataGridView = new DataGridView();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(930, 138);
            panel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Italic, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(856, 108);
            label5.Name = "label5";
            label5.Size = new Size(62, 20);
            label5.TabIndex = 2;
            label5.Text = "Admin...";
            label5.Click += label5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(345, 49);
            label1.Name = "label1";
            label1.Size = new Size(241, 40);
            label1.TabIndex = 1;
            label1.Text = "Halaman Utama";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtuang);
            groupBox1.Controls.Add(btnKonfirmasi);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(datePicker);
            groupBox1.Controls.Add(cmbJenis);
            groupBox1.Controls.Add(txtNama);
            groupBox1.Location = new Point(29, 460);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(435, 165);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Form Pembelian";
            // 
            // txtuang
            // 
            txtuang.Location = new Point(6, 59);
            txtuang.Name = "txtuang";
            txtuang.Size = new Size(151, 27);
            txtuang.TabIndex = 7;
            // 
            // btnKonfirmasi
            // 
            btnKonfirmasi.Location = new Point(173, 90);
            btnKonfirmasi.Name = "btnKonfirmasi";
            btnKonfirmasi.Size = new Size(245, 49);
            btnKonfirmasi.TabIndex = 6;
            btnKonfirmasi.Text = "Konfirmasi";
            btnKonfirmasi.UseVisualStyleBackColor = true;
            btnKonfirmasi.Click += btnKonfirmasi_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 36);
            label4.Name = "label4";
            label4.Size = new Size(101, 20);
            label4.TabIndex = 5;
            label4.Text = "Jumlah Uang :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 88);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 4;
            label3.Text = "Jenis Bank :";
            // 
            // datePicker
            // 
            datePicker.Enabled = false;
            datePicker.Location = new Point(173, 24);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(245, 27);
            datePicker.TabIndex = 3;
            // 
            // cmbJenis
            // 
            cmbJenis.FormattingEnabled = true;
            cmbJenis.Items.AddRange(new object[] { "BRI", "BNI", "BCA" });
            cmbJenis.Location = new Point(6, 111);
            cmbJenis.Name = "cmbJenis";
            cmbJenis.Size = new Size(151, 28);
            cmbJenis.TabIndex = 2;
            // 
            // txtNama
            // 
            txtNama.Location = new Point(173, 57);
            txtNama.Name = "txtNama";
            txtNama.PlaceholderText = "Nama Pembeli";
            txtNama.Size = new Size(245, 27);
            txtNama.TabIndex = 0;
            // 
            // rtbNota
            // 
            rtbNota.Location = new Point(487, 498);
            rtbNota.Name = "rtbNota";
            rtbNota.Size = new Size(414, 127);
            rtbNota.TabIndex = 3;
            rtbNota.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(487, 469);
            label2.Name = "label2";
            label2.Size = new Size(134, 20);
            label2.TabIndex = 4;
            label2.Text = "Nota Pembayaran :";
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(29, 171);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(872, 274);
            dataGridView.TabIndex = 5;
            dataGridView.CellClick += dataGridView_CellClick;
            // 
            // Pembeli
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(930, 658);
            Controls.Add(dataGridView);
            Controls.Add(label2);
            Controls.Add(rtbNota);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Name = "Pembeli";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Halaman Utama";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label5;
        private Label label1;
        private GroupBox groupBox1;
        private Button btnKonfirmasi;
        private Label label4;
        private Label label3;
        private DateTimePicker datePicker;
        private ComboBox cmbJenis;
        private TextBox txtUang;
        private TextBox txtNama;
        private RichTextBox rtbNota;
        private Label label2;
        private DataGridView dataGridView;
        private TextBox txtuang;
    }
}
