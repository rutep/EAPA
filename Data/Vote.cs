using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webApi.Data
{
    public class Vote
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        public string text { get; set; }

        public string Image { get; set; }

        public string date { get; set; }
    }
}
