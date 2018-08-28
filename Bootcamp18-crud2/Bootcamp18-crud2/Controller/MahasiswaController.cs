using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp18_crud2.Models;

namespace Bootcamp18_crud2.Controller
{
    class MahasiswaController
    {
        Entities1 context = new Entities1();
        Program panggil = new Program();
        int input;

        public void Menu()
        {
            int pilihan;

            do
            {
                Console.Clear();
                System.Console.WriteLine("============MENU=============");
                System.Console.WriteLine("1. View All");
                System.Console.WriteLine("2. Search by Id");
                System.Console.WriteLine("3. Insert");
                System.Console.WriteLine("4. Update");
                System.Console.WriteLine("5. Delete");
                System.Console.WriteLine("6. Menu Utama");
                System.Console.WriteLine("7. Exit");
                System.Console.WriteLine("=============================");
                System.Console.Write("Pilih no Action : ");


                pilihan = Convert.ToInt32(System.Console.ReadLine());

                switch (pilihan)
                {
                    case 1:
                        viewAll();
                        Console.ReadKey(true);
                        break;
                    case 2:
                        Console.Write("Masukkan ID yang di cari : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        SearchById2(input);

                        break;
                    case 3:
                        Insert();
                        break;
                    case 4:
                        Console.Write("Masukkan ID yang ingin di Update : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        Update(input);

                        break;
                    case 5:
                        Console.Write("Masukkan ID yang ingin di Delete : ");
                        input = Convert.ToInt32(Console.ReadLine());
                        Delete(input);

                        break;
                    case 6:
                        panggil.Menu();
                        break;
                    default:
                        Console.Write("Exit Cuy!");
                        break;
                }
            } while (pilihan != 7);
        }

        public void Insert()
        {
            string nama, alamat, telp, jenis_kelamin, universitas;
            DateTime tanggal_lahir;
            int jurusan_id;

            Console.Write("Masukkan Nama Lengkap     : ");
            nama = Console.ReadLine();
            Console.Write("Masukkan Alamat           : ");
            alamat = Console.ReadLine();
            Console.Write("Masukkan Jenis Kelamin    : ");
            jenis_kelamin = Console.ReadLine();
            Console.Write("Masukkan No Telp          : ");
            telp = Console.ReadLine();
            Console.Write("Masukkan Tanggal lahir    : ");
            tanggal_lahir = Convert.ToDateTime(Console.ReadLine());
            tanggal_lahir.ToString("MM/dd/yyyy");
            Console.Write("Masukkan Nama Universitas : ");
            universitas = Console.ReadLine();
            Console.Write("Masukkan ID Jurusan       : ");
            jurusan_id = Convert.ToInt32(Console.ReadLine());
            var getJurusan = context.tbl_jurusan.Find(jurusan_id);
            if (getJurusan == null)
            {
                Console.Write("ID Jurusan tidak ditemukan");
            }else
            {
                tbl_mahasiswa mahasiswa = new tbl_mahasiswa()
                {
                    nama = nama,
                    alamat = alamat,
                    jenis_kelamin = jenis_kelamin,
                    tanggal_lahir = tanggal_lahir,
                    no_telp = telp,
                    nama_universitas=universitas,
                    id_jurusan = jurusan_id

                };

                context.tbl_mahasiswa.Add(mahasiswa);
                context.SaveChanges();
            }
            
        }

        public int Update(int id)
        {
            string nama, alamat, telp, jenis_kelamin, universitas, tanggal, temp_tanggal;
            DateTime tanggal_lahir;
            int jurusan_id;

            var temp_mahasiswa = context.tbl_mahasiswa.Find(id);

            if (temp_mahasiswa == null)
            {
                Console.Write("ID tidak ditemukan!");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("=========Data sebelum terupdate=========");
                Console.WriteLine("Nama             : " + temp_mahasiswa.nama);
                Console.WriteLine("Alamat           : " + temp_mahasiswa.alamat);
                tanggal = temp_mahasiswa.tanggal_lahir.ToString();
                temp_tanggal = Convert.ToDateTime(tanggal).ToString("dd/MM/yyyy");
                Console.WriteLine("Tanggal Lahir    : " + temp_tanggal);
                Console.WriteLine("No Telp          : " + temp_mahasiswa.no_telp);
                Console.WriteLine("Jenis Kelamin    : " + temp_mahasiswa.jenis_kelamin);
                Console.WriteLine("Nama Universitas : " + temp_mahasiswa.nama_universitas);
                Console.WriteLine("Nama Jurusan     : " + temp_mahasiswa.tbl_jurusan.nama_jurusan);
                Console.WriteLine("=========================================\n");
                //Console.ReadKey(true);

                Console.Write("Masukkan Nama Lengkap     : ");
                nama = Console.ReadLine();
                Console.Write("Masukkan Alamat           : ");
                alamat = Console.ReadLine();
                Console.Write("Masukkan Jenis Kelamin    : ");
                jenis_kelamin = Console.ReadLine();
                Console.Write("Masukkan No Telp          : ");
                telp = Console.ReadLine();
                Console.Write("Masukkan Tanggal lahir    : ");
                tanggal_lahir = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Masukkan Nama Universitas : ");
                universitas = Console.ReadLine();
                Console.Write("Masukkan ID Jurusan       : ");
                jurusan_id = Convert.ToInt32(Console.ReadLine());
                var getJurusan = context.tbl_jurusan.Find(jurusan_id);
                if (getJurusan == null)
                {
                    Console.Write("ID Jurusan tidak ditemukan");
                }
                else
                {
                    tbl_mahasiswa mahasiswa = SearchById(id);

                    mahasiswa.nama = nama;
                    mahasiswa.alamat = alamat;
                    mahasiswa.jenis_kelamin = jenis_kelamin;
                    mahasiswa.tanggal_lahir = tanggal_lahir;
                    mahasiswa.no_telp = telp;
                    mahasiswa.nama_universitas = universitas;
                    mahasiswa.id_jurusan = jurusan_id;

                    context.Entry(mahasiswa).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();

                    Console.WriteLine("\n==========Data sesudah terupdate=========");
                    Console.WriteLine("Nama             : " + temp_mahasiswa.nama);
                    Console.WriteLine("Alamat           : " + temp_mahasiswa.alamat);
                    tanggal = mahasiswa.tanggal_lahir.ToString();
                    temp_tanggal = Convert.ToDateTime(tanggal).ToString("dd/MM/yyyy");
                    Console.WriteLine("Tanggal Lahir    : " + temp_tanggal);
                    Console.WriteLine("No Telp          : " + temp_mahasiswa.no_telp);
                    Console.WriteLine("Jenis Kelamin    : " + temp_mahasiswa.jenis_kelamin);
                    Console.WriteLine("Nama Universitas : " + temp_mahasiswa.nama_universitas);
                    Console.WriteLine("Nama Jurusan     : " + temp_mahasiswa.tbl_jurusan.nama_jurusan);
                    Console.WriteLine("=========================================");
                    Console.ReadKey(true);
                }
            }
            return id;
        }

        public int Delete(int id)
        {
            tbl_mahasiswa mahasiswa = SearchById(id);
            context.Entry(mahasiswa).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            Console.Write("Berhasil menghapus ID mahasiswa " + id);
            Console.ReadKey(true);
            return id;
        }

        public List<tbl_mahasiswa> viewAll()
        {
            var viewAll = context.tbl_mahasiswa.ToList();

            

            Console.WriteLine("\n============Data Mahasiswa============\n");
            foreach (tbl_mahasiswa mahasiswa in viewAll)
                {
                    Console.WriteLine("Id Mahasiswa     : " + mahasiswa.id);
                    Console.WriteLine("Nama             : " + mahasiswa.nama);
                    Console.WriteLine("Alamat           : " + mahasiswa.alamat);
                    string tanggal = mahasiswa.tanggal_lahir.ToString();
                    string temp_tanggal = Convert.ToDateTime(tanggal).ToString("dd/MM/yyyy");
                    Console.WriteLine("Tanggal Lahir    : " + temp_tanggal);
                    Console.WriteLine("No Telp          : " + mahasiswa.no_telp);
                    Console.WriteLine("Jenis Kelamin    : " + mahasiswa.jenis_kelamin);
                    Console.WriteLine("Nama Universitas : " + mahasiswa.nama_universitas);
                    Console.WriteLine("Nama Jurusan     : " + mahasiswa.tbl_jurusan.nama_jurusan);
                    Console.WriteLine("======================================");
            }
            
            return viewAll;
        }

        public tbl_mahasiswa SearchById(int id)
        {
            var mahasiswa = context.tbl_mahasiswa.Find(id);
            if (mahasiswa == null)
            {
                Console.WriteLine("ID Tidak Ditemukan!");
            }

            return mahasiswa;
        }

        public tbl_mahasiswa SearchById2(int id)
        {

            var mahasiswa = context.tbl_mahasiswa.Find(id);
            if (mahasiswa == null)
            {
                Console.WriteLine("ID Tidak Ditemukan!");
                Console.ReadKey(true);

            }
            else if (mahasiswa.id == id)
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("Nama             : " + mahasiswa.nama);
                Console.WriteLine("Alamat           : " + mahasiswa.alamat);
                string tanggal = mahasiswa.tanggal_lahir.ToString();
                string temp_tanggal = Convert.ToDateTime(tanggal).ToString("dd/MM/yyyy");
                Console.WriteLine("Tanggal Lahir    : " + mahasiswa.tanggal_lahir);
                Console.WriteLine("No Telp          : " + mahasiswa.no_telp);
                Console.WriteLine("Jenis Kelamin    : " + mahasiswa.jenis_kelamin);
                Console.WriteLine("Nama Universitas : " + mahasiswa.nama_universitas);
                Console.WriteLine("Nama Jurusan     : " + mahasiswa.tbl_jurusan.nama_jurusan);
                Console.WriteLine("=========================================");
                Console.ReadKey(true);

            }

            return mahasiswa;
        }

    }
}
