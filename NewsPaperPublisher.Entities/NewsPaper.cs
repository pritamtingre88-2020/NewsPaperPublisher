using System;
using System.Collections.Generic;

namespace NewsPaperPublisher.Entities
{
    public class NewsPaper
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public List<Page> Pages { get; set; }
    }
}
