using WebAPI.Models.Domain;

namespace WebAPI.Models.DTO
{
    public class RoleDTO
    {
        public Guid Id { get; set; }
        public string? UserRole { get; set; }
        public Guid UserId { get; set; }
    }
}
