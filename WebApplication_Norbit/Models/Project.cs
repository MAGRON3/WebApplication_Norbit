using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Norbit.Models
{
    public class Project
    {
        public int id { get; set; }
        public string name { get; set; }
        public int p_code { get; set; }
        public bool active { get; set; }
    }
}
