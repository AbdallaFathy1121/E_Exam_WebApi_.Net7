using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Question
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public string QuestionName { get; set; }
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string? A3 { get; set; }
        public string? A4 { get; set; }
        public string CorrectAnswer { get; set; }
        public object? Subject { get; set; }
    }
}
