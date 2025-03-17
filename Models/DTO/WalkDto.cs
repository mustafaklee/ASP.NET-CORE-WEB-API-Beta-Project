﻿namespace MyFirstApiProject.Models.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LengthInKm { get; set; }
        public string WalkImageUrl { get; set; }

        public RegionDto Regions { get; set; }
        public DifficultyDto Difficulty { get; set; }
    }
}
