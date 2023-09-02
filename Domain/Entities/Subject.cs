using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? TeacherId { get; set; }

        // Relations
        public virtual User? Teacher { get; set; }
    }
}
