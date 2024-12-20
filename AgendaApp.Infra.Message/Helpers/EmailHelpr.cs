using AgendaApp.Domain.Dtos.Responses;
using System.Net;
using System.Net.Mail;

namespace AgendaApp.Infra.Messages.Helpers
{
    public class EmailHelper
    {
        /// <summary>
        /// Método para realizar o envio de email.
        /// </summary>
        public void Send(CriarPessoaResponse pessoa)
        {
            // Configurações do e-mail remetente
            string emailRemetente = "aulamensageria.coti@hotmail.com";
            string senhaRemetente = "@Admin2024";

            // Configurações do SMTP
            SmtpClient smtpClient = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(emailRemetente, senhaRemetente),
                EnableSsl = true
            };

            // Criação do e-mail
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(emailRemetente),
                Subject = "Bem-vindo ao Sistema de Agenda",
                Body = $@"
                        <h1>Olá, {pessoa.Nome}!</h1>
                        <p>Bem-vindo ao Sistema de Agenda.</p>
                        <p>Estamos felizes por tê-lo conosco!</p>
                        <p><strong>Equipe AgendaApp</strong></p>",
                IsBodyHtml = true
            };

            // Destinatário
            mailMessage.To.Add(pessoa.Email);

            // Envio do e-mail
            smtpClient.Send(mailMessage);
        }
    }
}



