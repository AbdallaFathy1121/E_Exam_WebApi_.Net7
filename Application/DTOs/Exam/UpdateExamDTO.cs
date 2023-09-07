using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Exam
{
    public record UpdateExamDTO (
      DateTime StartDateTime,
      DateTime EndDateTime,
      string ExamName,
      int SubjectLevelId,
      string TeacherId
    );
}
