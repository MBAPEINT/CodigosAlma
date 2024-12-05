using System;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace CodigosAlma.Data
{
    public class SendMail
    {
        public void Enviar(string contacto)
        {
            try
            {
                // Create a new MimeMessage
                var message = new MimeMessage();

                // Set the sender
                message.From.Add(new MailboxAddress("Codigos del Alma", "ventas@rqerdoseternos.com"));

                // Set the recipient
                message.To.Add(new MailboxAddress("", "ventas@rqerdoseternos.com"));

                // Set the subject
                message.Subject = "SOLICITUD DE INFORMACIÓN";

                // Create the body of the email
                message.Body = new BodyBuilder
                {
                    HtmlBody = "<b>Número o Correo:</b> " + contacto
                }.ToMessageBody();

                // Create an SMTP client
                using (var client = new SmtpClient())
                {
                    // For testing purposes, accept all SSL certificates (not recommended for production)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    // Connect to the SMTP server
                    client.Connect("mail.rqerdoseternos.com", 465, SecureSocketOptions.SslOnConnect);

                    // Authenticate
                    client.Authenticate("ventas@rqerdoseternos.com", "Recuerdo$eternos2024");

                    // Send the email
                    client.Send(message);

                    // Disconnect from the server
                    client.Disconnect(true);
                }

                Console.WriteLine("Enviado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar: {ex.Message}");
            }
        }
    }
}