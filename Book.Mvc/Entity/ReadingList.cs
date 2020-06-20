using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Book.Mvc.Entity
{
    public class ReadingList
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime AdditionTime { get; set; }
        public List<Kitap> kitaps { get; set; }
        public int KitapId { get; set; }
        public  Kitap kitap  { get; set; }


      
    }
}