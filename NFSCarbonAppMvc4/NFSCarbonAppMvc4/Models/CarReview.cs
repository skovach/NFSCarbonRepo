using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NFSCarbonAppMvc4.Models
{
    public class CarReview : IValidatableObject
    {
        public int Id { get; set; }
        public int CarId { get; set; }

        [Display(Name = "User Name")]
        [DisplayFormat(NullDisplayText = "Anonymous")]
        public string ReveiwerName { get; set; }

        [Range(1,10, ErrorMessage = " Rating from 1 to 10")]
        public int Rating { get; set; }
        [Required(ErrorMessageResourceType = typeof(NFSCarbonAppMvc4.Views.Home.Resources), ErrorMessageResourceName = "Greeting")]
        [StringLength(2048)]
        public string Body { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Rating < 2 && ReveiwerName.ToLower().StartsWith("cero"))
            {
                yield return new ValidationResult("Sorry Cero, your the Best! :)");
            }
        }
    }
}