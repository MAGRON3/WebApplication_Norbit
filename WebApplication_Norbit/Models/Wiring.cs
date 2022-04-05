using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Norbit.Models
{
    public class Wiring
    {
        public int id { get; set; }
        public string name { get; set; }
        public int task_code { get; set; }
        public string w_date { get; set; }
        public int w_hours { get; set; }
    }
}
