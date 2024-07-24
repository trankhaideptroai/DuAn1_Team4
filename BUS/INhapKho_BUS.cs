using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Interface
{
    public interface INhapKho_BUS
    {
        #region source
        DataTable Load();

        bool Insert(NhapKho_DTO sp);

        bool Delete(string masp);

        bool Update(NhapKho_DTO sp);

        DataTable Find(string tensp);

        #endregion
    }
}
