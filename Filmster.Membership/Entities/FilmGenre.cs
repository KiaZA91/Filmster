﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filmster.Membership.Database.Entities;

namespace Filmster.Membership.Database.Entities
{
    public class FilmGenre
    {
        public int FilmId { get; set; }
        public int GenreId { get; set; }
        public virtual Film Film { get; set; } = null!;
        public virtual Genre Genre { get; set; } = null!;
    }
}
