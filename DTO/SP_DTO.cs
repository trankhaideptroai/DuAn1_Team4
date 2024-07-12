using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SP_DTO
    {
        public string maloai { get; set; }
        public string ten { get; set; }
        private int soluong { get; set; }   
        public int Soluong
        {
            get { return soluong; }
            set
            {
                if(value > 0)
                {
                    soluong = value;
                }
                else { }
            }
        }

        public string ngnhap { get; set; } 
        public string hsd { get; set; }    
        public string ncc { get; set; }
        public string email { get; set; }
    }
}
