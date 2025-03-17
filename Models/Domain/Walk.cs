﻿namespace MyFirstApiProjects.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }
        public string LengthInKm { get; set; }
        public string WalkImageUrl { get; set; }
        

        public Guid RegionId { get; set; }
        public Guid DifficultyId { get; set; }

        //Navigation properties
        public Region Regions { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
