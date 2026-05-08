namespace ReadingNook.API.Contracts.Sessions
{
    public record LogSessionRequest(int CurrentPage, bool MarkedAsFinished, string? Notes);

}
