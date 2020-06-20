using Book.Mvc.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book.Mvc.Models
{
    public class DetailModel
    {
        public int Id { get; set; }

        
        public string Yorum { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public DateTime CommentTime { get; set; }

        public Kitap kitaplar { get; set; }
        public List<Comment> comments { get; set; }
        public List<Comment> YazarComment { get; set; }
        public ReadingList readinglists { get; set; }

        
        public int KitapId { get; set; }
    }
}