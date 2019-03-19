using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vote.Data
{
    public class Vote
    {
        public int Id { get; set; }

        [Required]
        public String voteId { get; set; }
        [Required]
        public string Title { get; set; }

        public string text { get; set; }

        public string Image { get; set; }

        public string date { get; set; }
        public String pdfLink { get; set; }
    }
}
