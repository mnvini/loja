using System;
using System.ComponentModel.DataAnnotations;

namespace Vinicius.VirtualStore.Domain.Entities
{
    public class Order
    {
        [Required(ErrorMessage = "Enter your name")]
        public String ClientName { get; set; }
        
        [Display(Name = "Cep:")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Enter your address")]
        [Display(Name = "Address:")]
        public string Address { get; set; }

        [Display(Name = "Complement:")]
        public string Complement { get; set; }

        [Required(ErrorMessage = "Enter your city")]
        [Display(Name = "City:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter your neighborhood")]
        [Display(Name = "Neighborhood:")]
        public string Neighborhood { get; set; }

        [Required(ErrorMessage = "Enter your state")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Enter your email")]
        [Display(Name = "Email:")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        public Boolean GiftWrap { get; set; }
    }
}
