using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NFSCarbonAppMvc4.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
    }
}