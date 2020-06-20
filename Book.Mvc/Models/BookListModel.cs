using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book.Mvc.Models
{
    public class BookListModel
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Yazar { get; set; }
        public double Puan { get; set; }
        public bool Tavsiye { get; set; }
        public bool Home { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}