using Filmster.Membership.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Filmster.Membership.Database.Entities;

namespace Filmster.Membership.Database.Entities
{
    public class Director : IEntity
    {
        public Director()
        {
            Films = new HashSet<Film>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!; public virtual ICollection<Film> Films { get; set; }
    }
}