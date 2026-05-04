using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Domain.Entities
{
    public class ReadingSession
    {
        public int Id { get; set; }
        public DateTime ReadOn { get; set; }
        public int CurrentPage { get; set; }
        public bool MarkedAsFinished { get; set; }
        public string? Notes { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
