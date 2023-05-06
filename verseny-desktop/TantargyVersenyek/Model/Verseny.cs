using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TantargyVersenyek.Model
{
    public class Verseny
    {
        public string Id { get; set; }//property
        public string Competition_name { get; set; }
        public string Description { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
    }
}
