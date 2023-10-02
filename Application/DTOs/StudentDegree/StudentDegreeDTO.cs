using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.StudentDegree
{
    public record StudentDegreeDTO (
        int Id,
        int SubjectId,
        string SubjectName,
        string UserId,
        string UserName,
        int Degree,
        int ExamDegree
    );
}
