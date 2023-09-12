
using Microsoft.AspNetCore.Http;

namespace Application.DTOs.Subject
{
    public record UpdateSubjectDTO (
        string Name,
        IFormFile Image,
        string TeacherId
    );
}
