using System;
using System.Collections.Generic;

#nullable disable

namespace dvdrental.Entities
{
    public partial class Category
    {
        public Category()
        {
            FilmCategories = new HashSet<FilmCategory>();
        }

        public short CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual ICollection<FilmCategory> FilmCategories { get; set; }
    }
}
