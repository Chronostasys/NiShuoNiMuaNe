using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NiShuoNiMuaNe.Models
{
    public class Cai
    {
        [Key]
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public DateTime BaoZhiQi { get; set; }
        public double Weight { get; set; }
        public string Seller { get; set; }
    }
}
