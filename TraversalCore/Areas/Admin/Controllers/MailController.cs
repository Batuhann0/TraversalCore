using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCore.Models;

namespace TraversalCore.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            //göndericinin bilgileri
            MailboxAddress mailboxAddress = new MailboxAddress("Admin", "traversalcore1@gmail.com");
            mimeMessage.From.Add(mailboxAddress);

            //alıcının bilgileri 
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.RecevierMail);
            mimeMessage.To.Add(mailboxAddressTo);

            //mesajın içerik kısmı
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequest.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailRequest.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("traversalcore1@gmail.com", "mcjzhjouebmjkqua");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }
    }
}
//traversalcore1 @gmail.com
//123456Aa-