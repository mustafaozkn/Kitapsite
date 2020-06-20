using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Book.Mvc.Entity
{
    public class DataContext:DbContext
    {
        public DataContext():base("dataConnection")
        {

        }
        public DbSet<Kitap>  Kitaplar { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ReadingList> ReadingLists { get; set; }
    }
}