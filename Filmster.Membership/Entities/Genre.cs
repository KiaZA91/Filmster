using Filmster.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmster.Membership.Database.Entities
{
public class Genre : IEntity
    {
        public Genre()
        {
            Films = new HashSet<Film>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!; public virtual ICollection<Film> Films { get; set; }
    }


}
