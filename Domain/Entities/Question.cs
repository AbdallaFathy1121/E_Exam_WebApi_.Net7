using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionName { get; set; }
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string? A3 { get; set; }
        public string? A4 { get; set; }
        public string CorrectAnswer { get; set; }
        public int SubjectId { get; set; }


        // Relations
        public virtual Subject? Subject { get; set; }
    }
}
