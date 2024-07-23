using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface INhapKho_DAL
    {
        DataTable loadlist();

        bool insert(NhapKho_DTO sp);

        bool update(NhapKho_DTO sp);
        
        bool delete(string maload);

        DataTable finding(string tensp);
    }
}
