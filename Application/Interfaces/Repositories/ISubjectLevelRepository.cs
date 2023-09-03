using Application.DTOs.SubjectLevel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ISubjectLevelRepository: IBaseRepository<SubjectLevel>
    {
        Task<SubjectLevelDTO> GetAllSubjectLevelsAsync();
    }
}
