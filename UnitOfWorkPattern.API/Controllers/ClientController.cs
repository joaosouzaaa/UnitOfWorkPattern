using Microsoft.AspNetCore.Mvc;
using UnitOfWorkPattern.API.DataTransferObjects.Client;
using UnitOfWorkPattern.API.Interfaces.Services;
using UnitOfWorkPattern.API.Settings.NotificationSettings;

namespace UnitOfWorkPattern.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public sealed class ClientController(IClientService clientService) : ControllerBase
{
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task AddAsync([FromBody] ClientSave clientSave) =>
        clientService.AddAsync(clientSave);

    [HttpPost("add-triggers-pattern")]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Notification>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public Task AddAsyncTriggersUnitOfWorkPattern([FromBody] ClientSave clientSave) =>
        clientService.AddAsyncTriggersUnitOfWorkPattern(clientSave);
}
