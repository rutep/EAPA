using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Event.Data
{
    public class Event
    {
        
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        public string text { get; set; }

        public string Image { get; set; }

        public string date { get; set; }
    }
}