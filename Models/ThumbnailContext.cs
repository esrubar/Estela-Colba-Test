using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Estela_Colba_Test.Models
{
    public class ThumbnailContext: DbContext
    {
        public ThumbnailContext()
            :base("DefaultConnection")
        {

        }
        public DbSet<Thumbnail> Thumbnails { get; set; }
    }
}