using System;
using System.Collections.Generic;
using System.Text;

namespace MCC_CsOOP.Admin
{
    public interface IAdmin
    {
        void MainMenu();
        void InputData();
        public void ShowMenu();
        void ShowData();
        void RemoveData();
        //void EditData();
    }
}
