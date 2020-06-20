using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Book.Mvc.Entity
{
    public class Kitap
    {

        public int Id { get; set; }
        [DisplayName("Kitap Adı")] 
        public string Name { get; set; }
        [DisplayName("Kitap Detayı")]
        public string Description { get; set; }
        [DisplayName("Yazar")]
        public string Yazar { get; set; }
        [DisplayName("Kitap Puanı")]
        public double Puan { get; set; }
        [DisplayName("Tavsiye ?")]
        public bool Tavsiye { get; set; }
        [DisplayName("Anasayfada ?")]
        public bool Home { get; set; }
        [DisplayName("Sayfa Sayısı")]
        public double SayfaSayisi { get; set; }
        [DisplayName("Resim")]
        public string Image { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<ReadingList> readinglists { get; set; }

        public List<Comment> Comments { get; set; }
    }
}