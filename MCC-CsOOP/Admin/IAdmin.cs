using System;
using System.Collections.Generic;
using System.Text;

namespace MCC_CsOOP.Admin
{
    public interface IAdmin
    {
        void MainMenu();
        void InputData(List<Mahasiswa> mhsUniv);
        public void ShowMenu();
        void ShowData(List<Mahasiswa> mhsUniv);
        void RemoveData(List<Mahasiswa> mhsUniv);
        //void EditData();
    }
}
