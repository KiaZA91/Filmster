using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmster.Common.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Released { get; set; }
        public bool Free { get; set; }
        public string Description { get; set; }
        public string FilmUrl { get; set; }

        //navigation prop
        public int DirectorId { get; set; }
        public DirectorDTO Director { get; set; }
        public List<SimilarFilmsDTO> SimilarFilms { get; set; }
        public List<FilmGenreDTO> GenreDTOs { get; set; } = new();
        
    }

    public class FilmCreateDTO
    {
        public string Title { get; set; }
        public DateTime? Released { get; set; } = DateTime.Today;
        public bool Free { get; set; }
        public string Description { get; set; }
        public string FilmUrl { get; set; }
        public int DirectorId { get; set; }
    }
    public class FilmEditDTO : FilmCreateDTO
    {
        public int Id { get; set; }
    }
}
