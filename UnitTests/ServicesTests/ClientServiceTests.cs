using Moq;
using UnitOfWorkPattern.API.DataTransferObjects.Client;
using UnitOfWorkPattern.API.Entities;
using UnitOfWorkPattern.API.Interfaces.Repositories;
using UnitOfWorkPattern.API.Interfaces.Settings;
using UnitOfWorkPattern.API.Services;

namespace UnitTests.ServicesTests;
public sealed class ClientServiceTests
{
    private readonly Mock<IClientRepository> _clientRepositoryMock;
    private readonly Mock<ILogRepository> _logRepositoryMock;
    private readonly Mock<INotificationHandler> _notificationHandlerMock;
    private readonly ClientService _clientService;

    public ClientServiceTests()
    {
        _clientRepositoryMock = new Mock<IClientRepository>();
        _logRepositoryMock = new Mock<ILogRepository>();
        _notificationHandlerMock = new Mock<INotificationHandler>();
        _clientService = new ClientService(_clientRepositoryMock.Object, _logRepositoryMock.Object, _notificationHandlerMock.Object);
    }

    [Fact]
    public async Task AddAsync_SuccessfulScenario_CallAdd()
    {
        // A
        var clientSave = new ClientSave()
        {
            Age = 12,
            Balance = 20,
            Name = "Test"
        };

        _clientRepositoryMock.Setup(c => c.AddAsync(It.IsAny<Client>()));
        _logRepositoryMock.Setup(c => c.AddAsync(It.IsAny<Log>()));

        // A
        await _clientService.AddAsync(clientSave);

        // A
        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
        _clientRepositoryMock.Verify(c => c.AddAsync(It.IsAny<Client>()), Times.Once());
        _logRepositoryMock.Verify(c => c.AddAsync(It.IsAny<Log>()), Times.Once());
    }

    [Theory]
    [MemberData(nameof(InvalidClientParameters))]
    public async Task AddAsync_EntityInvalid_DoNotCallAdd(ClientSave clientSave)
    {
        await _clientService.AddAsync(clientSave);

        _notificationHandlerMock.Verify(n => n.AddNotification(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        _clientRepositoryMock.Verify(c => c.AddAsync(It.IsAny<Client>()), Times.Never());
        _logRepositoryMock.Verify(c => c.AddAsync(It.IsAny<Log>()), Times.Never());
    }

    public static IEnumerable<object[]> InvalidClientParameters()
    {
        yield return new object[]
        {
            new ClientSave()
            {
                Age = 0,
                Balance = 1,
                Name = "Test"
            }
        };

        yield return new object[]
        {
            new ClientSave()
            {
                Age = -20,
                Balance = 1,
                Name = "Test"
            }
        };

        yield return new object[]
        {
            new ClientSave()
            {
                Age = 10,
                Balance = 1,
                Name = ""
            }
        };

        yield return new object[]
        {
            new ClientSave()
            {
                Age = 9,
                Balance = 1,
                Name = new string('a', 101)
            }
        };
    }
}
