using WebAPI.Models.Domain;

namespace WebAPI.Models.DTO
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double? Length { get; set; }
        public Guid RegionId { get; set; }
        public Region? Region { get; set; }
        public Guid WalkDifficultyId { get; set; }
        public WalkDifficulty? WalkDifficulty { get; set; }
    }
}
