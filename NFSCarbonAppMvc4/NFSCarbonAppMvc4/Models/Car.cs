using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NFSCarbonAppMvc4.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Type  { get; set; }
        public string Vendor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string CarInfo { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<CarReview> CarReview { get; set; }
    }
}