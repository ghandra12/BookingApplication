﻿namespace BookingApplication.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImgPath { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
