using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dog_Seller.Models
{
    public class Dog
    {
        public int Id { get; set; }

        [Display(Name = "Age (months)")]
        public int Age { get; set; }

        public string Image { get; set; }

        [Required]
        public string Type { get; set; }

        [Display(Name = "Prise $")]
        public int Price { get; set; }
    }
}