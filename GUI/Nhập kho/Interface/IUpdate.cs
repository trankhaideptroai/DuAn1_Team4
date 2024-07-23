using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Nhập_kho.Interface
{
    public interface IUpdate
    {
        void open();

        void locked();

        void cleartext();

        void loadlist();

        void showinf();

        bool checkinput();

        bool checkten();

        bool checksoluong();

        bool checkncc();

        bool checkngnh();

        void inputvalues();

        void luu();

        void pas();
    }
}
