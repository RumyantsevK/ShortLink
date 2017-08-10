using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShortLink.Models
{
    public class Url
    {
        [Key]
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }
        public DateTime GenerationDate { get; set; }
    }
}