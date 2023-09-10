using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Exam
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
        public DateTime StartDateTime { get; set; } = DateTime.Now;
        public DateTime EndDateTime { get; set; } = DateTime.Now.AddHours(1);
        public int SubjectLevelId { get; set; }
        public string UserId { get; set; }


        // Relations
        public virtual SubjectLevel? SubjectLevel { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Question>? Questions { get; set; } = new HashSet<Question>();
    }
}
