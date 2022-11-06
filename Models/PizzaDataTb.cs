using System;
using System.Collections.Generic;

namespace DpizzaProject.Models
{
    public partial class PizzaDataTb
    {
        public PizzaDataTb()
        {
            Orderdatatales = new HashSet<Orderdatatale>();
        }

        public int PizzaId { get; set; }
        public string PizzaName { get; set; } = null!;
        public string PizzaType { get; set; } = null!;
        public string PizzCrust { get; set; } = null!;
        public decimal PizzaPrice { get; set; }
        public string NumberOfSlice { get; set; } = null!;
        public string? Img { get; set; }
        public string? Discription { get; set; }
        public string? VegNon { get; set; }

        public virtual ICollection<Orderdatatale> Orderdatatales { get; set; }
    }
}
