using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.StudentDegree
{
    public record AddStudentDegreeDTO (
        int SubjectId,
        string UserId,
        int Degree,
        int ExamDegree
    );
}
