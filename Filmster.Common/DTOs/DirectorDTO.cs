using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmster.Common.DTOs
{
    public class DirectorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DirectorCreateDTO
    {
        public string Name { get; set; }
    }
}
