using CodigosAlma.Data;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult EnviarCorreo()
        {
            SendMail mail = new SendMail();
            try
            {
                mail.Enviar();
                return Json(new { success = true, message = "Correo Enviado correctamente" });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "Error al enviar correo: " + e.Message });
            }
        }
    }
}
