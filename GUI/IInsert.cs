using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.Nhập_kho
{
    public interface IInsert
    {
        void open();

        void locked();

        void cleartext();

        bool checkinput();

        bool checkten();

        bool checksoluong();

        bool checkncc();

        void checkngnh();

        void inputvalues();

        void luu();

        void pas();

    }
}
