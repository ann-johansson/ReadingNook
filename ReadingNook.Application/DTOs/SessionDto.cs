using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Application.DTOs
{
    public class SessionDto
    {
        public int Id { get; set; }
        public DateTime ReadOn { get; set; }
        public int CurrentPage { get; set; }
        public bool MarkedAsFinished { get; set; }
        public string? Notes { get; set; }
        public int BookId { get; set; }
    }
}
