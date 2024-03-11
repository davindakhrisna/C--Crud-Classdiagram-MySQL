using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUD_PTS
{
    public class IsiPembeli
    {
        private string nama;
        private int uang;
        private string jenisbayar;
        private DateTime datepembayaran;
        private string model;

        public string Nama { get => nama; }
        public int Uang { get => uang; }
        public string JenisBayar { get => jenisbayar; }
        public DateTime DatePembayaran { get => datepembayaran; }
        public string Model { get => model; }

        IsiPembeli(string Getnama,
        int Getuang,
        string Getjenisbayar,
        DateTime Getdatepembayaran,
        string Getmodel)
        {
            this.nama = Getnama;
            this.uang = Getuang;
            this.jenisbayar = Getjenisbayar;
            this.datepembayaran = Getdatepembayaran;
            this.model = Getmodel;
        }
    }
}
