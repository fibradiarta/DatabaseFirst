using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp18_crud2.Models;

namespace Bootcamp18_crud2.Controller
{
    class JurusanController
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
                        ViewAll();
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
            string nama_jurusan;

            Console.Write("Masukkan Nama Jurusan     : ");
            nama_jurusan = Console.ReadLine();

            tbl_jurusan jurusan = new tbl_jurusan()
            {
                nama_jurusan = nama_jurusan
                    

            };

            context.tbl_jurusan.Add(jurusan);
            context.SaveChanges();
        }

        public List<tbl_jurusan> ViewAll()
        {
            var viewAll = context.tbl_jurusan.ToList();

            Console.WriteLine("---------------Data Jurusan----------------");
            Console.WriteLine(" ID Jurusan        Nama Jurusan    ");
            foreach (tbl_jurusan jurusan in viewAll)
            {
                Console.WriteLine("     " + jurusan.id + "       " + "    " + jurusan.nama_jurusan + "    ");
                /*Console.WriteLine("---------------------------------------");
                Console.WriteLine("Id Jurusan : " + jurusan.id);
                Console.WriteLine("Nama Jurusan : " + jurusan.nama_jurusan);
                Console.WriteLine("---------------------------------------");*/
                
            }
            return viewAll;
        }


        public tbl_jurusan SearchById(int id)
        {
            var jurusan = context.tbl_jurusan.Find(id);
            if (jurusan == null)
            {
                Console.WriteLine("ID Tidak Ditemukan!");
            }

            return jurusan;
        }

        public tbl_jurusan SearchById2(int id)
        {

            var jurusan = context.tbl_jurusan.Find(id);
            if (jurusan == null)
            {
                Console.WriteLine("ID Tidak Ditemukan!");
            }
            else if (jurusan.id == id)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Nama Jurusan : " + jurusan.nama_jurusan);
                Console.WriteLine("-----------------------------------------");
                Console.ReadKey(true);

            }

            return jurusan;
        }


        public int Update(int id)
        {
            string nama;
            var temp_jurusan = context.tbl_jurusan.Find(id);

            Console.WriteLine("------------Data sebelum di update----------");
            Console.WriteLine("Nama Jurusan : " + temp_jurusan.nama_jurusan);
            Console.WriteLine("-----------------------------------------\n");


            Console.Write("Masukkan Nama Jurusan     : ");
            nama = Console.ReadLine();

            tbl_jurusan jurusan = SearchById(id);
            jurusan.nama_jurusan = nama;

            context.Entry(jurusan).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            Console.WriteLine("\n==========Data sesudah di update==========");
            Console.WriteLine("Nama Jurusan : " + temp_jurusan.nama_jurusan);
            Console.WriteLine("=========================================");
            Console.ReadKey(true);

            return id;
            
            
        }

        public int Delete(int id)
        {
            tbl_jurusan jurusan = SearchById(id);
            context.Entry(jurusan).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
            Console.Write("Berhasil menghapus ID jurusan " + id);
            Console.ReadKey(true);
            return id;
        }
    }
}
