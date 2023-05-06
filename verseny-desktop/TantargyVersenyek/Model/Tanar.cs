using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TantargyVersenyek.Model
{
    public class Tanar
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Subject { get; set; }
        public string Class { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }
    }
}
