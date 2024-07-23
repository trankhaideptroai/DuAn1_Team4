using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BUS;
using DAL.Abstract;
using DAL.Interface;
using DTO;

namespace DAL
{
    public class NhapKho_DAL: AbsNhapKho_DAL, INhapKho_DAL
    {
        #region source

        // Thực thi proc
        public override bool Execute(string proc, params SqlParameter[] para)
        {
            using (SqlConnection con = DataProvider.connect())
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = proc;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(para);

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    con.Close();
                    return false;
                }
            }
        }

        // Tải danh sách
        public DataTable loadlist()
        {
            using (SqlConnection con = DataProvider.connect())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_nhkh_load", con);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                return dt;
            }
        }

        // Thêm
        public bool insert(NhapKho_DTO sp)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@maloai", sp.ML),
                new SqlParameter("@tensp", sp.Ten),
                new SqlParameter("@soluong", sp.SL),
                new SqlParameter("@ngaynh", sp.NgNH),
                new SqlParameter("@hsd", sp.HSD),
                new SqlParameter("@ncc", sp.NCC),
                new SqlParameter("@email", sp.Email)
            };
            return Execute("sp_nhkh_insert", para);
        }

        // Xóa
        public bool delete(string maloai)
        {
            return Execute("sp_nhkh_del", new SqlParameter("@maloai", maloai));
        }

        // Sửa
        public bool update(NhapKho_DTO sp)
        {
            SqlParameter[] para =
            {
                new SqlParameter("@maloai", sp.ML),
                new SqlParameter("@tensp", sp.Ten),
                new SqlParameter("@soluong", sp.SL),
                new SqlParameter("@ngaynh", sp.NgNH),
                new SqlParameter("@hsd", sp.HSD),
                new SqlParameter("@ncc", sp.NCC),
                new SqlParameter("@email", sp.Email)
            };
            return Execute("sp_nhkh_upd", para);
        }

        // Tìm kiếm
        public DataTable finding(string tensp)
        {
            using (SqlConnection con = DataProvider.connect())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_nhkh_findi", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tensp", tensp);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                con.Close();
                return dt;
            }
        }

        #endregion
    }
}
