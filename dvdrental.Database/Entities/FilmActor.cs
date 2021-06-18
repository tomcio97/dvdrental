using System;
using System.Collections.Generic;

#nullable disable

namespace dvdrental.Entities
{
    public partial class FilmActor
    {
        public short ActorId { get; set; }
        public short FilmId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Film Film { get; set; }
    }
}
