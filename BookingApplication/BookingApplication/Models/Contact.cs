﻿namespace BookingApplication.Models
{
 
    public class Contact
        {
            public Guid Id { get; set; }
            public string Email { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
    

}
