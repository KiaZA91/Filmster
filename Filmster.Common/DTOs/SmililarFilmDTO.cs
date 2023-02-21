using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmster.Common.DTOs
{
    public class SimilarFilmsDTO
    {
        public int FilmId { get; set; }
        public int SimilarFilmId { get; set; }

        //public FilmDTO Film { get; set; }
        //public FilmDTO Similar { get; set; }
    }
}
