using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Book.Mvc.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        public string Yorum { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime CommentTime { get; set; }  
        public int KitapId { get; set; }
        public Kitap Kitap { get; set; }

    }
    
}