namespace ReadingNook.API.Contracts.Books
{
    public record UpdateBookRequest(
        string Title,
        string Author,
        int TotalPages,
        string Genre,
        int? OverallRating);
}
