using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EABABackendQore.Model
{
    public class register
    {
        public string name { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string repeatPassword { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string other_email { get; set; }
        public string phone { get; set; }
        public string other_phone { get; set; }
        public string address { get; set; }
        public string other_address { get; set; }
        public string affiliation { get; set; }
        public string postcode { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string member_type { get; set; }
        public string status { get; set; }
    }
}
