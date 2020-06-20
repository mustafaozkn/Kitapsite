using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book.Mvc.Entity
{
    public class Category
    {
        public int Id { get; set; }
        [DisplayName("Kategori Adı")]
        [StringLength(maximumLength:15,ErrorMessage ="Maksimum 15 karakter girebilirsin.")]
        public string Name { get; set; }

        public List<Kitap> Books { get; set; }

    }
}