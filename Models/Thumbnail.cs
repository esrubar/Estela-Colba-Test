using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Estela_Colba_Test.Models
{
    public class Thumbnail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string OriginalRoute { get; set; }
        public string ThumbnailRoute { get; set; }
        public int visits { get; set; }

    }
}