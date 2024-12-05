using CodigosAlma.Data;
using Microsoft.AspNetCore.Mvc;
using CodigosAlma.Models;
using Microsoft.Extensions.Configuration;
using System;

namespace CodigosAlma.Controllers
{
    public class SendMailController : Controller
    {
        private readonly IConfiguration conf;

        public SendMailController(IConfiguration config)
        {
            conf = config;
        }

        [HttpPost]
        public IActionResult EnviarCorreo([FromBody] CMMailRequest request)
        {
            string contacto = request.Contacto;
            Console.WriteLine(contacto);
            SendMail mail = new SendMail();
            try
            {
                mail.Enviar(contacto);
                return Json(new { success = true, message = "Correo o número enviado con éxito" });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Error al enviar el contacto: " + e.Message });
            }
        }
    }
}
