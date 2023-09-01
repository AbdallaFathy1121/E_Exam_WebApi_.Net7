using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Level
{
    public record LevelDTO (
        int Id,  
        string Name
    );
}
