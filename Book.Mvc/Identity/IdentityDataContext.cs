using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Book.Mvc.Identity
{
    public class IdentityDataContext:IdentityDbContext<BooksUser>
    {
        public IdentityDataContext() : base("dataConnection")
        {
          
        }
    }
}