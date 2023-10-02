
using Microsoft.AspNetCore.Http;

namespace Application.DTOs.Subject
{
    public record AddSubjectDTO (
        string Name,
        string TeacherId
    );
}
