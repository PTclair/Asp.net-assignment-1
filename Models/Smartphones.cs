using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PranavSmartphones.Models
{
    public class Smartphones
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public decimal Stroge { get; set; }
        public decimal Price { get; set; }

    }
}
