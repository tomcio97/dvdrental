using System;
using System.Collections.Generic;

#nullable disable

namespace dvdrental.Entities
{
    public partial class Inventory
    {
        public Inventory()
        {
            Rentals = new HashSet<Rental>();
        }

        public int InventoryId { get; set; }
        public short FilmId { get; set; }
        public short StoreId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Film Film { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}
