using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretSanta.Data
{
    public class GroupAssignment
    {
        public int AssignmentId { get; set; }
        public int GroupId { get; set; }
        public List<Assignment> Assignments = new();

    }
}
