using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CRUD_PTS
{
    public partial class Pembeli : Form
    {
        public Pembeli()
        {
            InitializeComponent();

            InitializeConnection();
            DisplayData();

            dataGridView.RowTemplate.Height = 100; // Ubah angka sesuai kebutuhan
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

                dataGridView.DataSource = dataTable;

                // Atur lebar kolom
                dataGridView.Columns["Nama"].Width = 150;
                DataGridViewImageColumn imgCol = (DataGridViewImageColumn)dataGridView.Columns["Gambar"];
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
            dataGridView.Columns["Id"].Visible = false; // Kolom ini tidak terlihat oleh pengguna
            ((DataGridViewImageColumn)dataGridView.Columns["Gambar"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
        }




        // Anda bisa memanggil method ini dari constructor atau dari event handler lainnya
        // Misalnya dari button yang mengupdate data atau saat form di-load



        private MySqlConnection connect;
        private void InitializeConnection()
        {
            string connectionString = $"SERVER=localhost;DATABASE=database;UID=root;PASSWORD=;";
            connect = new MySqlConnection(connectionString);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            using (Login loginForm = new Login())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    string username = loginForm.Username;
                    string password = loginForm.Password;

                    Admin adminForm = new Admin();
                    adminForm.Show();
                    this.Hide();
                }
            }
        }

        private void btnKonfirmasi_Click(object sender, EventArgs e)
        {
            // Pastikan ada baris yang dipilih
            if (dataGridView.SelectedRows.Count > 0)
            {
                string nama = txtNama.Text;
                string jenis = cmbJenis.Text;
                int Uang = int.Parse(txtuang.Text);

                string model = dataGridView.SelectedRows[0].Cells["Model"].Value.ToString();
                int harga = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Harga"].Value);


                if (Uang < harga)
                {
                    MessageBox.Show("Uang Anda Tidak Cukup!");
                }
                else
                {
                    int Kembalian = Uang - harga;

                    if (connect.State == ConnectionState.Closed)
                    {
                        connect.Open();
                    }

                    rtbNota.Text = $"Terima kasih atas pembelian, {nama}.\n\n" +
                                   $"Anda telah melakukan pembelian mobil dengan model {model}.\n" +
                                   $"Total pembayaran: Rp {harga:N0}.\n" +
                                   $"Jenis pembayaran: {jenis}.\n" +
                                   $"Tanggal pembayaran: {datePicker.Value.ToString("dd MMMM yyyy")}.\n\n" +
                                   $"Kembalian: Rp {Kembalian:N0}.\n\n" +
                                   $"Mohon simpan nota ini sebagai bukti pembayaran. Terima kasih atas kunjungan Anda!";


                    string customer = "INSERT INTO Customer (Nama, Uang, Jenisbayar, Kembalian, Datepembayaran, Model, Nota) VALUES (@Nama, @Uang, @Jenisbayar, @Kembalian, @Datepembayaran, @Model, @Nota)";
                    MySqlCommand commandcustomer = new MySqlCommand(customer, connect);
                    commandcustomer.Parameters.AddWithValue("@Nama", nama);
                    commandcustomer.Parameters.AddWithValue("@Uang", Uang);
                    commandcustomer.Parameters.AddWithValue("@Jenisbayar", jenis);
                    commandcustomer.Parameters.AddWithValue("@Kembalian", Kembalian);
                    commandcustomer.Parameters.AddWithValue("@Datepembayaran", datePicker.Value);
                    commandcustomer.Parameters.AddWithValue("@Model", model);
                    commandcustomer.Parameters.AddWithValue("@Nota", rtbNota.Text);
                    commandcustomer.ExecuteNonQuery();

                    int selectedId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);

                    string query = "DELETE FROM Mobil WHERE Id = @Id";
                    MySqlCommand command = new MySqlCommand(query, connect);
                    command.Parameters.AddWithValue("@Id", selectedId);

                    try
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Hapus baris dari DataGridView setelah penghapusan dari database berhasil
                            dataGridView.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
                            MessageBox.Show("Terimakasih Telah Memakai Layanan Kami!");
                        }
                        else
                        {
                            MessageBox.Show("Transaksi Gagal");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        txtNama.Text = null;
                        txtuang.Text = null;
                        cmbJenis.Text = null;
                        connect.Close();
                        DisplayData();
                    }
                }
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rtbNota.Text = null;
        }
    }
}
