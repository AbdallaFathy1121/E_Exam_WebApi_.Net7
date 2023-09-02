using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Subject
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string? TeacherName { get; set; }
    }
}