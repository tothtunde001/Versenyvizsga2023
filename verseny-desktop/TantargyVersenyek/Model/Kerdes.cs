using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TantargyVersenyek.Model
{
    public class Kerdes
    {
        public string Id { get; set; }
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string CorrectAnswer { get; set; }
        public string CompetitionId { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }

    }
}
