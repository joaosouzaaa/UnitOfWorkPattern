using Moq;
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
}
