
namespace Application.DTOs.Subject
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public byte[] Image { get; set; }
        public object? Teacher { get; set; }
    }
}