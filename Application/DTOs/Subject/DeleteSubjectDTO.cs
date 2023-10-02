using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Subject
{
    public record DeleteSubjectDTO (
        int Id,
        string TeacherId
    );
}
