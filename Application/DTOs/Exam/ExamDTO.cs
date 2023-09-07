using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Exam
{
    public class ExamDTO
    {
        public int Id { get; set; }
        public string ExamName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public object? Subject { get; set; }
        public object? Level { get; set; }
        public object? Teacher { get; set; }
    }
}
