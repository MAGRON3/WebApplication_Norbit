using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Norbit.Models
{
    public class Task
    {
        public int id { get; set; }
        public string name { get; set; }
        public int project_code { get; set; }
        public bool active { get; set; }
    }
}
