using System;
using System.Collections.Generic;

using MCC_CsOOP.Admin;

namespace MCC_CsOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            CAdmin adminJurusan = new CAdmin("Admin Jurusan", "admin@jurusan.com");
            adminJurusan.MainMenu();

        } // End of Main method

    } // end of class Program
} // end of namespace DataMahasiswa
