using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StudentDegree
    {
        public int Id { get; set; }
        public int Degree { get; set; }
        public int ExamDegree { get; set; }

        public int SubjectId { get; set; }
        public string UserId { get; set; }

        // Relations
        public virtual Subject? Subject { get; set; }
        public virtual User? User { get; set; }
    }
}
