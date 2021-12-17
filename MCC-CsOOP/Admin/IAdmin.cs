using System;
using System.Collections.Generic;
using System.Text;

namespace MCC_CsOOP.Admin
{
    public interface IAdmin
    {
        void InputData(List<Mahasiswa> mhsUniv);
        void ShowData(List<Mahasiswa> mhsUniv);
        void RemoveData(List<Mahasiswa> mhsUniv);
        //void EditData();
    }
}
