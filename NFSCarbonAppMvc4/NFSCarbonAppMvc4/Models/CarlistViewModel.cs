using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NFSCarbonAppMvc4.Models
{
    public class CarlistViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Vendor { get; set; }
        public decimal Price { get; set; }
        public string Info { get; set; }
        public ICollection<string> ImagePath { get; set; }
        public double AvgRating { get; set; }
        public int RatingCount { get; set; }
        public string Type { get; set; }
    }
}