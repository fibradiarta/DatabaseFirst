using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bootcamp18_crud2.Controller;

namespace Bootcamp18_crud2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=======MENU=======");
            Console.WriteLine("1. Mahasiswa");
            Console.WriteLine("2. Jurusan");
            Console.WriteLine("==================");
            Console.Write("Pilih Action : ");
            int choice = Convert.ToInt32(System.Console.ReadLine());
            switch (choice)
            {
                case 1:
                    MahasiswaController callMahasiswa = new MahasiswaController();
                    callMahasiswa.Menu();
                    break;
                case 2:
                    JurusanController callJurusan = new JurusanController();
                    callJurusan.Menu();
                    break;
                default:
                    System.Console.Write("Periksa kembali");
                    System.Console.Read();
                    break;
            }
        }
    }
}
