using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book.Mvc.Identity
{
    public class BooksRole:IdentityRole
    {
        public string Description { get; set; }
        public BooksRole()
        {

        }

        public BooksRole(string rolename,string description)
        {
            this.Description = description;
        }
    }
}