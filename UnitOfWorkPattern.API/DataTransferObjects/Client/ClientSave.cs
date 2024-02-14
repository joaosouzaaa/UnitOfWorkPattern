namespace UnitOfWorkPattern.API.DataTransferObjects.Client;

public sealed class ClientSave
{
    public required string Name { get; set; }
    public required int Age { get; set; }
    public required decimal Balance { get; set; }
}
