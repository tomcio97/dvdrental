using System;
using System.Collections.Generic;

#nullable disable

namespace dvdrental.Entities
{
    public partial class Language
    {
        public Language()
        {
            Films = new HashSet<Film>();
        }

        public short LanguageId { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
