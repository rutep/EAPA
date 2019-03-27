using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardMemberEntity.Data

{
    public class BoardMember
    {
         public int Id { get; set; }

        public string Name { get; set; }
        public string BoardRole { get; set; }
        public string text { get; set; }
        public string Image { get; set; }
    }

}
