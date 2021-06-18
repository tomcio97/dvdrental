using System;
using System.Collections.Generic;
using NpgsqlTypes;

#nullable disable

namespace dvdrental.Entities
{
    public partial class Film
    {
        public Film()
        {
            FilmActors = new HashSet<FilmActor>();
            FilmCategories = new HashSet<FilmCategory>();
            Inventories = new HashSet<Inventory>();
        }

        public short FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReleaseYear { get; set; }
        public short LanguageId { get; set; }
        public short RentalDuration { get; set; }
        public decimal RentalRate { get; set; }
        public short? Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public DateTime LastUpdate { get; set; }
        public string[] SpecialFeatures { get; set; }
        public NpgsqlTsVector Fulltext { get; set; }

        public virtual Language Language { get; set; }
        public virtual ICollection<FilmActor> FilmActors { get; set; }
        public virtual ICollection<FilmCategory> FilmCategories { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
