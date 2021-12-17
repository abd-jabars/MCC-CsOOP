using System;
using System.Collections.Generic;
using System.Text;

namespace MCC_CsOOP.Admin
{
    public interface IAdmin
    {
        void MainMenu(List<Mahasiswa> mhsUniv);
        void InputData(List<Mahasiswa> mhsUniv);
        public void ShowMenu(List<Mahasiswa> mhsUniv);
        void ShowData(List<Mahasiswa> mhsUniv);
        void RemoveData(List<Mahasiswa> mhsUniv);
        //void EditData();
    }
}
