using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_PTS
{
    public class IsiMobil
    {
        private string model;
        private string nama;
        private int harga;
        private string jenis;
        private string transmisi;
        private string kondisi;
        private int tahun;
        private string lokasi;
        private byte[] gambar;

        public string Model { get => model; }
        public string Nama { get => nama; }
        public int Harga { get => harga; }
        public string Jenis { get => jenis;}
        public string Transmisi { get => transmisi; }
        public string Kondisi { get => kondisi; }
        public int Tahun { get => tahun; }
        public string Lokasi { get => lokasi; }
        public byte[] Gambar { get => gambar; }

        public void Mobil(string nama, string model, int harga, string jenis, string transmisi, string kondisi, int tahun, string lokasi, byte[] gambar)
        {
            this.nama = nama;
            this.model = model;
            this.harga = harga;
            this.jenis = jenis;
            this.transmisi = transmisi;
            this.kondisi = kondisi;
            this.tahun = tahun;
            this.lokasi = lokasi;
            this.gambar = gambar;
        }
        public void EditMobil(string nama, string model, int harga, string jenis, string transmisi, string kondisi, int tahun, string lokasi, byte[] gambar)
        {
            this.nama = nama;
            this.model = model;
            this.harga = harga;
            this.jenis = jenis;
            this.transmisi = transmisi;
            this.kondisi = kondisi;
            this.tahun = tahun;
            this.lokasi = lokasi;
            this.gambar = gambar;
        }
    }
}
