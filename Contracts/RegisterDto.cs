using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class RegisterDto
    {
        public Guid Id { get; set; }
        public Guid CDRId { get; set; }
        public Guid ParticipantId { get; set; }

    }
}
