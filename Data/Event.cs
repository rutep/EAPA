﻿using System.ComponentModel.DataAnnotations;

namespace Event.Data
{
    public class Event
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }
        public string text { get; set; }

        

    }
}