using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public abstract class AbsNhapKho_DTO
    {
        protected string maloai {  get; set; }
        protected string ten {  get; set; }
        protected int soluong { get; set; }
        protected string ngnh { get; set; }
        protected string hsd { get; set; }
        protected string ncc { get; set; }
        protected string email { get; set; }


        public string ML { get; set; }
        public string Ten { get; set; }

        public int SL
        {
            get { return soluong; }
            set
            {
                if (value > 0)
                {
                    soluong = value;
                }
                else { }
            }
        }
        public string NgNH { get; set; }
        public string HSD { get; set; }
        public string NCC { get; set; }
        public string Email { get; set; }

    }
}
