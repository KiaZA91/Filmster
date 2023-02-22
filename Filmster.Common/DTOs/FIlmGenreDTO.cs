using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmster.Common.DTOs
{
    public class FilmGenreDTO
    {
        public int FilmId { get; set; }
        public int GenreId { get; set; }
    }
}
public class FilmGenreCreateDTO
{
	public int FilmId { get; set; }
	public int GenreId { get; set; }
}

