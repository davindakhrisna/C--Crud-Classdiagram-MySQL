using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_PTS
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            InitializeConnection();
            DisplayData();
            DisplayCustomerData();

            dataGridView1.RowTemplate.Height = 100; // Ubah angka sesuai kebutuhan
        }

        private void DisplayCustomerData()
        {
            // Pastikan koneksi terbuka
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }

            // Query SQL untuk mengambil data dari tabel Customer
            string query = "SELECT Nama, Uang, Jenisbayar, Kembalian, Datepembayaran, Model FROM Customer";

            // Buat objek command dengan query dan koneksi yang telah disediakan
            MySqlCommand command = new MySqlCommand(query, connect);

            try
            {
                DataTable dataTable = new DataTable();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }

                // Set data source untuk DataGridView kedua
                dataGridView2.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Tutup koneksi setelah selesai menggunakan
                connect.Close();
            }
        }


        private void DisplayData()
        {
            // Pastikan koneksi terbuka
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }

            // Query SQL untuk mengambil data dari tabel Mobil
            string query = "SELECT ID, Nama, Model, Harga, Jenis, Transmisi, Kondisi, Tahun, Lokasi, Gambar FROM Mobil";

            // Buat objek command dengan query dan koneksi yang telah disediakan
            MySqlCommand command = new MySqlCommand(query, connect);

            try
            {
                DataTable dataTable = new DataTable();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }

                dataGridView1.DataSource = dataTable;

                // Atur lebar kolom
                dataGridView1.Columns["Nama"].Width = 150;
                DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dataGridView1.Columns["Gambar"];
                imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Tutup koneksi setelah selesai menggunakan
                connect.Close();
            }
            dataGridView1.Columns["Id"].Visible = false; // Kolom ini tidak terlihat oleh pengguna
        }




        // Anda bisa memanggil method ini dari constructor atau dari event handler lainnya
        // Misalnya dari button yang mengupdate data atau saat form di-load



        private MySqlConnection connect;
        private void InitializeConnection()
        {
            string connectionString = $"SERVER=localhost;DATABASE=database;UID=root;PASSWORD=;";
            connect = new MySqlConnection(connectionString);
        }


        private void btnTambah_Click(object sender, EventArgs e)
        {
            // Pastikan koneksi terbuka
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }

            byte[] imageData = null;
            if (pictureBox.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox.Image.Save(ms, pictureBox.Image.RawFormat);
                    imageData = ms.ToArray();
                }
            }

            int Harga = int.Parse(txtHarga.Text);
            int Tahun = int.Parse(cmbTahun.Text);

            IsiMobil mobil = new IsiMobil();
            mobil.Mobil(txtNama.Text, txtModel.Text, Harga, cmbJenis.Text, cmbTransmisi.Text, cmbKondisi.Text, Tahun, txtLokasi.Text, imageData);

            // Query SQL untuk menambahkan data
            string query = "INSERT INTO Mobil (Nama, Model, Harga, Jenis, Transmisi, Kondisi, Tahun, Lokasi, Gambar) " +
                              "VALUES (@Nama, @Model, @Harga, @Jenis, @Transmisi, @Kondisi, @Tahun, @Lokasi, @Gambar)";

            // Buat objek command dengan query dan koneksi yang telah disediakan
            MySqlCommand command = new MySqlCommand(query, connect);

            // Isi parameter dengan nilai-nilai dari input pengguna
            command.Parameters.AddWithValue("@Nama", mobil.Nama);
            command.Parameters.AddWithValue("@Model", mobil.Model);
            command.Parameters.AddWithValue("@Harga", mobil.Harga);
            command.Parameters.AddWithValue("@Jenis", mobil.Jenis);
            command.Parameters.AddWithValue("@Transmisi", mobil.Transmisi);
            command.Parameters.AddWithValue("@Kondisi", mobil.Kondisi);
            command.Parameters.AddWithValue("@Tahun", mobil.Tahun);
            command.Parameters.AddWithValue("@Lokasi", mobil.Lokasi);
            command.Parameters.AddWithValue("@Gambar", mobil.Gambar);

            try
            {
                // Jalankan perintah untuk menambahkan data
                int rowsAffected = command.ExecuteNonQuery();

                // Periksa apakah data berhasil ditambahkan
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data berhasil ditambahkan.");
                }
                else
                {
                    MessageBox.Show("Gagal menambahkan data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }
            DisplayData();
        }
        private void btnPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            // Menampilkan dialog untuk memilih file gambar
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Mengambil nama file gambar yang dipilih
                    string selectedFile = openFileDialog1.FileName;

                    // Memuat gambar ke PictureBox
                    pictureBox.Image = new System.Drawing.Bitmap(selectedFile);
                }
                catch (Exception ex)
                {
                    // Menampilkan pesan kesalahan jika terjadi kesalahan saat memuat gambar
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        // EDIT -------------->

        public Image image;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                groupBox1.BringToFront();

                btnEdit.Enabled = true;
                btnHapus.Enabled = true;

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                edtNama.Text = row.Cells["Nama"].Value.ToString();
                edtModel.Text = row.Cells["Model"].Value.ToString();
                edtHarga.Text = row.Cells["Harga"].Value.ToString();
                edtCmbTipe.Text = row.Cells["Jenis"].Value.ToString();
                edtCmbTransmisi.Text = row.Cells["Transmisi"].Value.ToString();
                edtCmbKondisi.Text = row.Cells["Kondisi"].Value.ToString();
                edtCmbTahun.Text = row.Cells["Tahun"].Value.ToString();
                edtLokasi.Text = row.Cells["Lokasi"].Value.ToString();
                byte[] imageData = (byte[])row.Cells["Gambar"].Value;

                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    image = Image.FromStream(ms);
                }
                edtPictureBox.Image = image;
            }
            else
            {
                gpxTambah.BringToFront();
                btnHapus.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        public byte[] imageData = null;

        private void btnEditPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            // Menampilkan dialog untuk memilih file gambar
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Mengambil nama file gambar yang dipilih
                    string selectedFile = openFileDialog1.FileName;

                    // Memuat gambar ke PictureBox
                    edtPictureBox.Image = new System.Drawing.Bitmap(selectedFile);

                    if (edtPictureBox.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            edtPictureBox.Image.Save(ms, edtPictureBox.Image.RawFormat);
                            imageData = ms.ToArray();
                        }
                    }

                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }

                    string gambarQuery = "UPDATE Mobil SET Gambar = @Gambar WHERE ID = @Id";
                    MySqlCommand gambarCommand = new MySqlCommand(gambarQuery, connect);
                    gambarCommand.Parameters.AddWithValue("@Gambar", imageData);


                    int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                    gambarCommand.Parameters.AddWithValue("@Id", selectedId);

                    gambarCommand.ExecuteNonQuery();

                    connect.Close();
                }
                catch (Exception ex)
                {
                    // Menampilkan pesan kesalahan jika terjadi kesalahan saat memuat gambar
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }

            int edtHargaMobil = int.Parse(edtHarga.Text);
            int edtTahunMobil = int.Parse(edtCmbTahun.Text);

            IsiMobil mobil = new IsiMobil();
            mobil.EditMobil(edtNama.Text, edtModel.Text, edtHargaMobil, edtCmbTipe.Text, edtCmbTransmisi.Text, edtCmbKondisi.Text, edtTahunMobil, edtLokasi.Text, imageData);

            string query = "UPDATE Mobil SET Nama = @Nama, Model = @Model, Harga = @Harga, Jenis = @Jenis, Transmisi = @Transmisi, Kondisi = @Kondisi, Tahun = @Tahun, Lokasi = @Lokasi WHERE ID = @Id";

            MySqlCommand command = new MySqlCommand(query, connect);

            command.Parameters.AddWithValue("@Nama", mobil.Nama);
            command.Parameters.AddWithValue("@Model", mobil.Model);
            command.Parameters.AddWithValue("@Harga", mobil.Harga);
            command.Parameters.AddWithValue("@Jenis", mobil.Jenis);
            command.Parameters.AddWithValue("@Transmisi", mobil.Transmisi);
            command.Parameters.AddWithValue("@Kondisi", mobil.Kondisi);
            command.Parameters.AddWithValue("@Tahun", mobil.Tahun);
            command.Parameters.AddWithValue("@Lokasi", mobil.Lokasi);

            int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            command.Parameters.AddWithValue("@Id", selectedId);

            try
            {
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Data berhasil diupdate.");
                }
                else
                {
                    MessageBox.Show("Gagal mengupdate data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connect.Close();
            }

            btnEdit.Enabled = false;
            btnHapus.Enabled = false;
            gpxTambah.BringToFront();
            DisplayData();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            // Pastikan ada baris yang dipilih
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Ambil nilai ID dari baris yang dipilih
                int selectedId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                // Konfirmasi penghapusan dengan user
                DialogResult result = MessageBox.Show("Anda yakin ingin menghapus item ini?", "Konfirmasi Penghapusan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Lakukan penghapusan dari database
                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }

                    string query = "DELETE FROM Mobil WHERE Id = @Id";
                    MySqlCommand command = new MySqlCommand(query, connect);
                    command.Parameters.AddWithValue("@Id", selectedId);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Hapus baris dari DataGridView setelah penghapusan dari database berhasil
                            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            MessageBox.Show("Data berhasil dihapus.");
                        }
                        else
                        {
                            MessageBox.Show("Gagal menghapus data.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih baris yang ingin dihapus.");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pembeli beli = new Pembeli();
            beli.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayCustomerData();
        }
    }
}
