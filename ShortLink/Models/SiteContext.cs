using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShortLink.Models
{
    public class SiteContext : DbContext
    {
        public SiteContext()
            : base("name=SiteContext")
        { }
        public DbSet<Url> Urls { get; set; }
    }
}