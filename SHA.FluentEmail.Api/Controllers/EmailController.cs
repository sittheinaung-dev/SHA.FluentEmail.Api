using Microsoft.AspNetCore.Mvc;

namespace SHA.FluentEmail.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        //[HttpPost]
        //public async Task<IActionResult> SendAsync([FromBody] EmailRequestModel requestModel)
        //{
        //    var model = await _emailService.SendAsync(requestModel.ToEmail, requestModel.Subject, requestModel.Body);
        //    return Ok(model);
        //}
        [HttpPost]
        public async Task<IActionResult> SendAsync([FromBody] EmailRequestModel requestModel)
        {
            var response = await _emailService.SendEmail(
                requestModel.ToEmail,
                requestModel.Subject,
                requestModel.Body
            );

            return Ok(response);
        }
    }

}
       

