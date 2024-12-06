using CodigosAlma.Models;
using CodigosAlma.Data.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Reflection;

namespace CodigosAlma.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioDB usuarioDB = new UsuarioDB();
    }
}