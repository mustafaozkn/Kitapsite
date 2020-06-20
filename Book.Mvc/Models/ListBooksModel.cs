using Book.Mvc.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Book.Mvc.Models
{
    public class ListBooksModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        [DisplayName("Kitap Adı")]
        public string BookName { get; set; }
        [DisplayName("Kitap Yazarı")]
        public double Puan { get; set; }
        [DisplayName("Kitap Puanı")]
        public string Yazar { get; set; }
        public string Image { get; set; }
        public int KitapId { get; set; }

        [DisplayName("Eklenme Tarihi")]
        public DateTime EklenmeTarihi { get; set; }

        public List<ReadingList> readinglist { get; set; }
        public List<Kitap> kitaplar { get; set; }
    }
}