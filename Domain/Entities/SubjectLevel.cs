using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SubjectLevel
    {
        public int Id { get; set; }
        public int LevelId { get; set; }
        public int SubjectId { get; set; }

        // Relations
        public virtual Level? Level { get; set; } = null;
        public virtual Subject? Subject { get; set; } = null;
    }
}
