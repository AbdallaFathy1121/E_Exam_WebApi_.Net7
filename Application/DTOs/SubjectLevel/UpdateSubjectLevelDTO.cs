using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.SubjectLevel
{
    public record UpdateSubjectLevelDTO (
      int LevelId,
      int SubjectId
    );
}
