using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ofertas.Comum.Utils
{
    public static class Sendgrid
    {
        public static async Task SendConfirmationEmailAsync(string Email, string Nome)
        {
            //var apiKey = Environment.GetEnvironmentVariable("PartilhadoAPIChaveSecreta");
            //var apiKey = Environment.GetEnvironmentVariable("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");
            var apiKey = "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";

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("kinjaprod@gmail.com", "Partilhado");
            var subject = "Confirme seu email!";
            var to = new EmailAddress(Email, Nome);

            string content = "<code> <strong>Clique no botão abaixo para confirmar seu email:</strong> <br><br> <a href=";

            var plainTextContent = "Clique no botão abaixo para confirmar seu email:";
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        public static async Task SendWelcomeEmailAsync(string Email, string Nome)
        {
            var apiKey = "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";

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("kinjaprod@gmail.com", "Partilhado");
            var subject = "Bem-vindo ao Partilhado!";
            var to = new EmailAddress(Email, Nome);

            var plainTextContent = "Comece a reservar doações e produtos com ";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

    }
}
