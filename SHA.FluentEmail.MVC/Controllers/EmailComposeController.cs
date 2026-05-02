using Microsoft.AspNetCore.Mvc;
using SHA.FluentEmail.Api;
using SHA.FluentEmail.MVC.Models;
using SHA.FluentEmail.MVC.Services;

namespace SHA.FluentEmail.MVC.Controllers
{
    public class EmailComposeController : Controller
    {
        private readonly IEmailApiService _emailService;
        public EmailComposeController(IEmailApiService emailService)
        {
            _emailService = emailService;
        }

        public IActionResult Send()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Send(EmailViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var request = new EmailRequestModel
            {
                ToEmail = model.ToEmail,
                Subject = model.Subject,
                Body = model.Body
            };

            var response = await _emailService.SendEmailAsync(request);

            if (response.Successful)
            {
                ViewBag.Message = "Email sent successfully!";
            }
            else
            {
                ViewBag.Message = "Failed to send email: " +
                                  string.Join(", ", response.ErrorMessages);
            }

            return View();
        }
    }
}
