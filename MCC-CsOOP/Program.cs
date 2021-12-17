using System;
using System.Collections.Generic;

using MCC_CsOOP.Admin;

namespace MCC_CsOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            CAdmin newAdmin = new CAdmin("Sleepy Admin", "sleepy_admin@univ.com");
            List<Mahasiswa> mhsUniv = new List<Mahasiswa>();

            int exit = 0;
            do
            {
                newAdmin.MainMenu();
                String selectMenu = Console.ReadLine();
                switch (selectMenu)
                {
                    case "1":
                        newAdmin.InputData(mhsUniv);
                        newAdmin.ShowMenu();
                        break;
                    case "2":
                        newAdmin.ShowData(mhsUniv);
                        newAdmin.ShowMenu();
                        break;
                    case "3":
                        newAdmin.RemoveData(mhsUniv);
                        newAdmin.ShowMenu();
                        break;
                    case "4":
                        newAdmin.ConfirmExit();
                        break;
                    default:
                        newAdmin.MainMenu();
                        break;
                } // end of switch case

            } while (exit == 0);

        } // End of Main method

    } // end of class Program
} // end of namespace DataMahasiswa
