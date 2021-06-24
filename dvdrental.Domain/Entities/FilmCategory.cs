using System;
using System.Collections.Generic;

#nullable disable

namespace dvdrental.Entities
{
    public partial class FilmCategory
    {
        public short FilmId { get; set; }
        public short CategoryId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Category Category { get; set; }
        public virtual Film Film { get; set; }
    }
}
