using System;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace CodigosAlma.Data
{
    public class SendMail
    {
        public void Enviar()
        {
            try
            {
                // Create a new MimeMessage
                var message = new MimeMessage();

                // Set the sender
                message.From.Add(new MailboxAddress("Codigos del Alma", "ventas@rqerdoseternos.com"));

                // Set the recipient
                message.To.Add(new MailboxAddress("", "mbapeint2003@gmail.com"));

                // Set the subject
                message.Subject = "PRUEBA CORREO";

                // Create the body of the email
                message.Body = new BodyBuilder
                {
                    HtmlBody = "Pruebas <b>Pruebas</b>"
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