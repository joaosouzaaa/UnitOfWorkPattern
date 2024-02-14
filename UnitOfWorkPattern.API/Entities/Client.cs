namespace UnitOfWorkPattern.API.Entities;

public sealed class Client
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Age { get; set; }
    public required decimal Balance { get; set; }
}
