using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notification;


    public NotificationController(INotificationService notification)
    {
        _notification = notification;
    }


    [HttpPost]
    public async Task<IActionResult> Send()
    {
        await _notification.TaskCreated("Hello From API");
        return Ok();
    }

}