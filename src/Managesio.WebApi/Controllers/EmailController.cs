using Managesio.Core.Modules.EmailModule.Services;
using Microsoft.AspNetCore.Mvc;

namespace Managesio.WebApi.Controllers;

[ApiController]
[Route("api/email")]
public class EmailController
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    [Route("send")]
    public async Task SendEmail()
    {
        await _emailService.SendEmail();
    }

}