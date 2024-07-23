using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using BUS.Interface;
using System.Data;

namespace BUS
{
    public class NhapKho_BUS : INhapKho_BUS
    {
        NhapKho_DAL sp2 = new NhapKho_DAL();

        #region source

        // Tải danh sách
        public DataTable Load()
        {
            return sp2.loadlist();
        }

        // Thêm
        public bool Insert(NhapKho_DTO sp)
        {
            return sp2.insert(sp);
        }

        // Xóa
        public bool Delete(string masp)
        {
            return sp2.delete(masp);
        }

        // Sửa
        public bool Update(NhapKho_DTO sp)
        {
            return sp2.update(sp);
        }

        // Tìm kiếm
        public DataTable Find(string tensp)
        {
            return sp2.finding(tensp);
        }

#endregion
    }
}
