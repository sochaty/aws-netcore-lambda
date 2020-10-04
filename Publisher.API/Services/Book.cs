using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Publisher.API.Services
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string PublishingHouse { get; set; }
        public DateTime PublishedOn { get; set; }
    }
}
