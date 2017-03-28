using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APM.WebApi.Models
{
    public class Product
    {
        public string Description { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product must have a product code")]
        public string ProductCode { get; set; }

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name required", AllowEmptyStrings = false)]
        [MinLength(4, ErrorMessage = "Min length of 4 chars")]
        [MaxLength(12, ErrorMessage = "Product name should be at most 12 characters")]
        public string ProductName { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}