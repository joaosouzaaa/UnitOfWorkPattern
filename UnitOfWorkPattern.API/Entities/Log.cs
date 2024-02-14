namespace UnitOfWorkPattern.API.Entities;

public sealed class Log
{
    public int Id { get; set; }
    public required string Message { get; set; }
    public required DateTime Date { get; set; }
}
