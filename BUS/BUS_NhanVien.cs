using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BUS
{
    public class BUS_NhanVien
    {
        DAL_NhanVien dAL_NhanVien = new DAL_NhanVien();
        public bool checklogin(string email, string password)
        {
            
            return dAL_NhanVien.CheckLogin(email, password);
        }
        

    }
}
