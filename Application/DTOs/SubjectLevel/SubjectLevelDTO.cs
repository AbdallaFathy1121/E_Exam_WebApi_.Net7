using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.SubjectLevel
{
    public class SubjectLevelDTO
    {
        public int Id { get; set; }
        public object? Level { get; set; }
        public object? Subject { get; set; }
    }
}
