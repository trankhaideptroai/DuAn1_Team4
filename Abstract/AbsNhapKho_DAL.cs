using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public abstract class AbsNhapKho_DAL
    {
        public abstract bool Execute(string proc, params SqlParameter[] para);
    }
}
