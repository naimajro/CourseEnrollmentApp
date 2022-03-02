using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Register
    {
        public Guid Id { get; set; }
        public Guid CDRId { get; set; }
        public ICollection<Participant> Participants { get; set; }
    }
}
