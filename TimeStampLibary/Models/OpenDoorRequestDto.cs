﻿using System.Security;

namespace TimeStampLibary.Models
{

    public class OpenDoorRequestDto
    {
        public string? BadgeId { get; set; }
        public string? StampId { get; set; }
    }
}