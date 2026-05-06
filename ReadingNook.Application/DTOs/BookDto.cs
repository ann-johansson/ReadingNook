using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingNook.Application.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int TotalPages { get; set; }
        public string Genre { get; set; } = string.Empty;
        public int? OverallRating { get; set; }
    }
}
