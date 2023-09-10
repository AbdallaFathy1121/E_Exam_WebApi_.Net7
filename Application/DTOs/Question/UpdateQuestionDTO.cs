using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Question
{
    public record UpdateQuestionDTO (
      int ExamId,
      string QuestionName,
      string A1,
      string A2,
      string? A3,
      string? A4,
      string CorrectAnswer
    );
}
