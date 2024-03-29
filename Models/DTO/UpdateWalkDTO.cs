﻿using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTO
{
    public class UpdateWalkDTO
    {
        public string? Name { get; set; }
        public double? Length { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkDifficultyId { get; set; }
    }
}
