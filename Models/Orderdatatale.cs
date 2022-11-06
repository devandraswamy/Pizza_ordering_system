using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace DpizzaProject.Models
{
    public partial class Orderdatatale
    {
        public int Orderid { get; set; }
        public int? Pizzaid { get; set; }

        [Required]
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string? Customername { get; set; }
        public string? CustomerAddress { get; set; }
        public DateTime? Dateoforder { get; set; }
        public string? Toppins { get; set; }
        public string? Slices { get; set; }

        public virtual PizzaDataTb? Pizza { get; set; }
    }
}
