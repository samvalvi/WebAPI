﻿using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models.DTO
{
    public class UpdateRegionDTO
    {

        public string? Code { get; set; }
        public string? Name { get; set; }
        public double? Area { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public long? Population { get; set; }
    }
}
